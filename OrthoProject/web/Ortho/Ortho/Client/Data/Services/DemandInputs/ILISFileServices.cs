using Ortho.Shared.Enums;
using Ortho.Shared.Models;
using Ortho.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ortho.Client.Data.Services.DemandInputs
{
    public interface ILISFileServices
    {
        bool Accepts(ConfigLisField zone);
        string Data { get; set; }
        void StartDrag(string data, ConfigLisField zone);
        Task<IEnumerable<LISFileAndColumnMappingViewModel>> GetLISFileAndColumnMappingsAsync(int userId, int customerId);
        Task<int> SaveActionAsync(LISFilePostViewModel lisFilePostViewModel);
        Task<bool> UpdateFileColumnMappingAsync(List<DemandFileColumnMapping> fileColumnMappings);
        Task<List<DemandLISFileViewModel>> GetAllDemandLisFilesAsync();
        Task<bool> CheckScenarioWithLISFileAsync(int lisFileId);
    }
}
