using Ortho.Shared.Models;
using Ortho.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ortho.Client.Data.Services.ScenarioDefinition
{
    public interface IScenarioServices
    {
        Task<IEnumerable<ConfigDemandSource>> GetConfigDemandSources();
        Task<IEnumerable<ConfigLabType>> GetConfigLabTypes();
        Task<IEnumerable<ConfigScenarioType>> GetConfigScenarioTypes();
        Task<IEnumerable<AppUserViewModel>> GetAppUsers();
        Task<IEnumerable<ExtCustomer>> GetExtCustomersAsync();
        Task<ScenarioDefinitionViewModel> GetScenarioDefintionAsync(string scenarioId);
        Task<bool> SaveActionAsync(ScenarioDefinitionViewModel scenarioDefinition);
        Task<bool> CreateCustomerAsync(ScenarioDefinitionViewModel scenarioDefinition);
        Task<bool> CreateScenarioAsync(ScenarioDefinitionViewModel scenarioDefinition);
    }
}
