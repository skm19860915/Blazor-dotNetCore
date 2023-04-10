using Ortho.Shared.Models;
using Ortho.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ortho.Client.Data.Services.ScenarioManager
{
    public interface IManagerServices
    {
        Task<IEnumerable<ConfigScenarioType>> GetConfigScenarioTypes();
        Task<IEnumerable<AppUserViewModel>> GetAppUsers();
        Task<IEnumerable<ScenarioManagerViewModel>> GetScenarioManagersAsync();
        Task<int> CreateScenarioAsync(ScenarioDefinitionViewModel scenarioDefinitionViewModel);
        Task<bool> RemoveScenarioAsync(int scenarioId);
        Task<bool> UndoScenarioAsync(int scenarioId);
        Task<bool> DeleteScenarioAsync(int scenarioId);
    }
}
