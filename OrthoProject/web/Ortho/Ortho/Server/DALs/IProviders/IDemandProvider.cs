using Ortho.Shared.Models;
using Ortho.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ortho.Server.DALs.IProviders
{
    public interface IDemandProvider
    {
        Task<List<ConfigOrthoAssay>> GetConfigOrthoAssaysAsync();
        Task<List<Panel>> GetPanelsAsync();
        Task<IEnumerable<PanelViewModel>> GetPermanentPanelsAsync();
        Task<IEnumerable<PanelViewModel>> GetUserDefinedPanelsAsync(int userId);
        Task<IEnumerable<PanelAssayViewModel>> GetAllAssaysAsync();
        Task<bool> DeletePanelAsync(int panelId);
        Task<bool> UpdatePanelAsync(PanelViewModel panelViewModel);
        Task<IEnumerable<DemandLISFile>> GetLISFilesAsync(int userId, int customerId);
        Task<IEnumerable<DemandFileColumnMapping>> GetDemandFileColumnMappingsAsync(int scenarioId);
        Task<IEnumerable<LISFileAndColumnMappingViewModel>> GetLISFileAndColumnMappingsAsync(int userId, int customerId);
        Task<int> CreateLISFileAsync(LISFilePostViewModel lisFilePostViewModel);
        Task<bool> UpdateFileColumnMappingAsync(List<DemandFileColumnMapping> fileColumnMappings);
        Task<List<DemandLISFileViewModel>> GetAllDemandLisFilesAsync();
        Task<bool> CheckScenarioWithLISFileAsync(int lisFileId);
    }
}
