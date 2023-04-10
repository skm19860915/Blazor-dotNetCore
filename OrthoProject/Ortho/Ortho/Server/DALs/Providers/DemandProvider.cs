using Microsoft.EntityFrameworkCore;
using Ortho.Server.DALs.IProviders;
using Ortho.Shared.Mappings;
using Ortho.Shared.Models;
using Ortho.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ortho.Server.DALs.Providers
{
    /// <summary>
    /// Demand Inputs ServiceProvider
    /// </summary>
    public class DemandProvider : IDemandProvider
    {
        private readonly OrthoDBContext _dbContext;
        public DemandProvider(OrthoDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ConfigOrthoAssay>> GetConfigOrthoAssaysAsync()
        {
            var configOrthoAssays = await _dbContext.configOrthoAssays.ToListAsync();
            return configOrthoAssays;
        }

        public async Task<List<Panel>> GetPanelsAsync()
        {
            var panels = await _dbContext.panels
                .Include(a => a.panelAssays)
                .ThenInclude(c => c.assay)
                .ToListAsync();

            return panels;
        }

        public async Task<IEnumerable<PanelViewModel>> GetPermanentPanelsAsync()
        {
            var panels = await GetPanelsAsync();
            var permanentPanels = panels.Where(p => p.global == true)
                .OrderBy(p => p.name)
                .Select(p => p.ToPanelViewModel());
            return permanentPanels;
        }

        public async Task<IEnumerable<PanelViewModel>> GetUserDefinedPanelsAsync(int userId)
        {
            var panels = await GetPanelsAsync();
            var userDefinedPanels = panels.Where(p => p.global == false && p.userId == userId)
                .OrderBy(u => u.name)
                .Select(p => p.ToPanelViewModel());
            return userDefinedPanels;
        }

        public async Task<IEnumerable<PanelAssayViewModel>> GetAllAssaysAsync()
        {
            var configOrthoAssays = await GetConfigOrthoAssaysAsync();
            var allAssays = configOrthoAssays.Where(c => c.on == true)
                .OrderBy(o => o.name)
                .Select(a => a.ToPanelAssayViewModelWithConfigOrthoAssay());
            return allAssays;
        }

        public async Task<bool> DeletePanelAsync(int panelId)
        {
            var isDeletedPanelAssay = await DeletePanelAssayAsync(panelId);
            if (!isDeletedPanelAssay)
                return false;

            var existing = await _dbContext.panels.FirstOrDefaultAsync(s => s.panelId == panelId);
            if (existing == null)
                return false;

            try
            {
                _dbContext.Remove(existing);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeletePanelAssayAsync(int panelId)
        {
            var existing = await _dbContext.panelAssays.FirstOrDefaultAsync(a => a.panelId == panelId);
            if (existing == null)
                return true;

            try
            {
                _dbContext.Remove(existing);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdatePanelAsync(PanelViewModel panelViewModel)
        {
            if (panelViewModel.Id == 0)
            {
                var IsCreated = await CreatePanelAsync(panelViewModel);
                return IsCreated;
            }

            var existingPanel = await _dbContext.panels.FirstOrDefaultAsync(p => p.panelId == panelViewModel.Id);
            if (existingPanel == null)
                return false;

            bool isUpdatedPanel;
            existingPanel.name = panelViewModel.PanelName;
            try
            {
                _dbContext.Update(existingPanel);
                await _dbContext.SaveChangesAsync();
                isUpdatedPanel = true;
            }
            catch
            {
                isUpdatedPanel= false;
            }

            if (!isUpdatedPanel)
                return false;

            var isUpdatedPanelAssays = await UpdatePanelAssaysAsync(panelViewModel);
            return isUpdatedPanelAssays;
        }

        private async Task<bool> CreatePanelAsync(PanelViewModel panelViewModel)
        {
            bool isCreatedPanel;
            var newPanel = panelViewModel.ToPanel();
            try
            {
                _dbContext.Add(newPanel);
                await _dbContext.SaveChangesAsync();
                isCreatedPanel = true;
            }
            catch
            {
                isCreatedPanel = false;
            }

            if (!isCreatedPanel)
                return false;

            if (!panelViewModel.PanelAssays.Any())
                return true;

            var panels = await _dbContext.panels.ToListAsync();
            var newPanelId = panels.OrderByDescending(s => s.panelId).First().panelId;
            var isAddedPanelAssays = await AddPanelAssaysAsync(newPanelId, panelViewModel.PanelAssays);
            return isAddedPanelAssays;
        }

        private async Task<bool> AddPanelAssaysAsync(int panelId, List<PanelAssayViewModel> panelAssays)
        {
            var addedPanelAssays = panelAssays.Select(a => a.ToPanelAssay(panelId));
            try
            {
                _dbContext.AddRange(addedPanelAssays);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdatePanelAssaysAsync(PanelViewModel panelViewModel)
        {
            if (!panelViewModel.PanelAssays.Any())
                return true;

            var allAssays = await _dbContext.panelAssays.ToListAsync();
            var existingAssays = allAssays.Where(a => a.panelId == panelViewModel.Id);

            try
            {
                var updatedPanelAssays = panelViewModel.PanelAssays.Select(u => u.ToPanelAssay(panelViewModel.Id)).ToList();
                _dbContext.RemoveRange(existingAssays);
                _dbContext.AddRange(updatedPanelAssays);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<DemandLISFile>> GetLISFilesAsync(int userId, int customerId)
        {
            var lisFiles = await _dbContext.demandLisFiles
                .Where(d => d.userId == userId && d.customerId == customerId).ToListAsync();
            return lisFiles;
        }

        public async Task<IEnumerable<DemandFileColumnMapping>> GetDemandFileColumnMappingsAsync(int lisSetId)
        {
            var demandFileColumnMappings = await _dbContext.demandFileColumnMappings.
                Where(d => d.lisSetId == lisSetId).OrderBy(d => d.columnNumber).ToListAsync();
            return demandFileColumnMappings;
        }

        public async Task<IEnumerable<LISFileAndColumnMappingViewModel>> GetLISFileAndColumnMappingsAsync(int userId, int customerId)
        {
            var lisFiles = await GetLISFilesAsync(userId, customerId);

            var list = new List<LISFileAndColumnMappingViewModel>();
            foreach (var lisFile in lisFiles)
            {
                var demandFileColumnMappings = await GetDemandFileColumnMappingsAsync(lisFile.lisSetId);
                var record = new LISFileAndColumnMappingViewModel
                {
                    Id = lisFile.lisSetId,
                    FileName = lisFile.fileName,
                    UserId = lisFile.userId,
                    LISFileHeader = lisFile.lisFile,
                    CustomerId = lisFile.customerId,
                    DemandFileColumnMappings = demandFileColumnMappings
                };
                list.Add(record);
            }
            return list;
        }

        public async Task<bool> CreateLISFileMappingDataAsync(LISDataPostViewModel lisDataPostViewModel)
        {
            var isCreated = await CreateDemandLISFileAsync(lisDataPostViewModel);
            if (!isCreated)
                return false;

            var lisFiles = await _dbContext.demandLisFiles.ToListAsync();
            var lastId = lisFiles.OrderByDescending(l => l.lisSetId).First().lisSetId;

            var demandFileColumnMappings = lisDataPostViewModel.csvDataList
                .Select(c => c.ToLISFileColumnMappings(lastId, lisDataPostViewModel.ScenarioId)).ToList();

            try
            {
                _dbContext.AddRange(demandFileColumnMappings);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> CreateDemandLISFileAsync(LISDataPostViewModel lisDataPostViewModel)
        {
            var file = new DemandLISFile
            {
                userId = lisDataPostViewModel.UserId,
                scenarioIdFirstLoad = 1,
                newCustomerData = true,
                fileName = lisDataPostViewModel.FileName,
                uploadDt = DateTime.Now,
                customerId = lisDataPostViewModel.CustomerId,
                lisFile = lisDataPostViewModel.LISFileHeader
            };

            try
            {
                _dbContext.Add(file);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateFileColumnMappingAsync(List<DemandFileColumnMapping> fileColumnMappings)
        {
            try
            {
                _dbContext.UpdateRange(fileColumnMappings);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<string>> GetAllDemandLisFilesAsync()
        {
            var allDemandLISFiles = await _dbContext.demandLisFiles.ToListAsync();
            var fileNames = allDemandLISFiles.Select(f => f.fileName).ToList();
            return fileNames;
        }
    }
}
