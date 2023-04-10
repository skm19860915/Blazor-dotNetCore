using Ortho.Client.Data.ViewModels.DemandInputs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ortho.Client.Data.Services.DemandInputs
{
    public interface IAssayMappingServices
    {
        Task<IEnumerable<PriorityModel>> GetPrioritiesAsync();
        Task<IEnumerable<MapTypeModel>> GetMapTypesAsync();
        Task<IEnumerable<MapValueModel>> GetMapValuesAsync();
        Task<IEnumerable<AssayMappingViewModel>> GetAssayMappingListAsync();
        Task<IEnumerable<string>> GetMapTypeNameListAsync();
        Task<IEnumerable<string>> GetMapValueNameListAsync();
    }
}
