using Ortho.Shared.Models;
using Ortho.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ortho.Server.DALs.IProviders
{
    public interface IScenarioProvider
    {
        Task<List<ConfigDemandSource>> GetConfigDemandSourcesAsync();
        Task<List<ConfigLabType>> GetConfigLabTypesAsync();
        Task<List<ConfigScenarioType>> GetConfigScenarioTypesAsync();
        Task<List<AppUserViewModel>> GetAppUsersAsync();
        Task<List<ExtCustomer>> GetExtCustomersAsync();
        Task<List<Scenario>> GetScenariosAsync();
        Task<IEnumerable<ScenarioManagerViewModel>> GetScenarioManagersAsync();
        Task<int> CreateScenarioAsync(ScenarioDefinitionViewModel scenarioDefinitionViewModel);
        Task<bool> UpdateScenarioAsync(ScenarioDefinitionViewModel scenarioDefinitionViewModel);
        Task<bool> RemoveScenarioAsync(int scenarioId);
        Task<bool> UndoScenarioAsync(int scenarioId);
        Task<bool> DeleteScenarioAsync(int scenarioId);
        Task<int> CreateCustomerAsync(ScenarioDefinitionViewModel scenarioDefinitionViewModel);
        Task<bool> UpdateCustomerAsync(ScenarioDefinitionViewModel scenarioDefinitionViewModel);
    }
}
