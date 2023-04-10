using Microsoft.EntityFrameworkCore;
using Ortho.Server.BusinessLogic;
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
                    LisSetId = lisFile.lisSetId,
                    UserId = lisFile.userId,
                    FileName = lisFile.fileName,
                    CustomerId = lisFile.customerId,
                    DemandFileColumnMappings = demandFileColumnMappings
                };
                list.Add(record);
            }
            return list;
        }

        public async Task<int> CreateLISFileAsync(LISFilePostViewModel lisFilePostViewModel)
        {
            int targetLisFileId = 0;

            var isCreated = await CreateDemandLISFileAsync(lisFilePostViewModel);
            if (!isCreated)
                return 0;

            var lisFiles = await _dbContext.demandLisFiles.ToListAsync();

            var isExistingRecord = lisFiles.FirstOrDefault(d => string.Equals(d.fileName, lisFilePostViewModel.FileName));

            if (isExistingRecord != null)
                targetLisFileId = isExistingRecord.lisSetId;
            else
                targetLisFileId = lisFiles.OrderByDescending(l => l.lisSetId).First().lisSetId;

            var updatedScenarioId = Convert.ToInt32(lisFilePostViewModel.ScenarioId);
            var isUpdatedScenario = await UpdateScenarioWithLISFileIdAsync(targetLisFileId, updatedScenarioId);
            if (!isUpdatedScenario)
                return 0;

            var processId = LISFileProcessor.InitializeLISHeaders(_dbContext, lisFilePostViewModel.UserId, 
                Convert.ToInt32(lisFilePostViewModel.ScenarioId), targetLisFileId);

            var errorId = CheckHeaderProcessId(processId);
            if (errorId == 0)
                return targetLisFileId;

            return errorId;
        }

        private int CheckHeaderProcessId(int processId)
        {
            int errorId = 0;
            switch (processId)
            {
                case LISFileProcessor.ERR_NONE:
                    break;
                case LISFileProcessor.ERR_LIS_FILE_EXCEPTION:
                    errorId = -1;
                    break;
                case LISFileProcessor.ERR_LIS_FILE_NOT_FOUND_IN_DATABASE:
                    errorId = -2;
                    break;
                case LISFileProcessor.ERR_NO_HEADER_LINE_DETECTED:
                    errorId = -3;
                    break;
                case LISFileProcessor.ERR_TOO_FEW_COLUMNS:
                    errorId = -4;
                    break;
                case LISFileProcessor.ERR_LIS_NO_DATA_DETECTED:
                    errorId = -5;
                    break;
                case LISFileProcessor.ERR_MAPPING_REQ_FLD_NOT_MAPPED:
                    errorId = -6;
                    break;
                case LISFileProcessor.ERR_MAPPING_COLS_FAILED:
                    errorId = -7;
                    break;
            }
            return errorId;
        }

        public async Task<bool> CreateDemandLISFileAsync(LISFilePostViewModel lisFilePostViewModel)
        {
            var demandLisFiles = await _dbContext.demandLisFiles.ToListAsync();
            var isExistingRecord = demandLisFiles.FirstOrDefault(d => string.Equals(d.fileName, lisFilePostViewModel.FileName));

            var file = new DemandLISFile
            {
                userId = lisFilePostViewModel.UserId,
                scenarioIdFirstLoad = 1,
                newCustomerData = true,
                fileName = lisFilePostViewModel.FileName,
                uploadDt = DateTime.Now,
                customerId = lisFilePostViewModel.CustomerId,
                lisFile = lisFilePostViewModel.LISFile
            };

            if (isExistingRecord != null)
            {
                isExistingRecord.lisFile = lisFilePostViewModel.LISFile;
                isExistingRecord.uploadDt = DateTime.Now;
            }

            try
            {
                if (isExistingRecord != null)
                    _dbContext.Update(isExistingRecord);
                else
                    _dbContext.Add(file);

                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateScenarioWithLISFileIdAsync(int lastId, int scenarioId)
        {
            var existing = await _dbContext.scenarios.FirstOrDefaultAsync(e => e.scenarioId == scenarioId);
            if (existing == null)
                return false;

            existing.lisSetId = lastId;
            try
            {
                _dbContext.Update(existing);
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

        public async Task<List<DemandLISFileViewModel>> GetAllDemandLisFilesAsync()
        {
            var allDemandLISFiles = await _dbContext.demandLisFiles.ToListAsync();
            var fileNames = allDemandLISFiles.Select(f => f.ToDemandLISFileViewModel()).ToList();
            return fileNames;
        }

        public async Task<bool> CheckScenarioWithLISFileAsync(int lisFileId)
        {
            var existing = await _dbContext.scenarios.AnyAsync(e => e.lisSetId == lisFileId);
            return existing;
        }
    }
}
