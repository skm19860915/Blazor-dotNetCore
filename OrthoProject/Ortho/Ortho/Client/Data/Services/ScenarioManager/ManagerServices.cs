using Ortho.Shared.Models;
using Ortho.Shared.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Ortho.Client.Data.Services.ScenarioManager
{
    /// <summary>
    /// Scenario Manager Sevice
    /// </summary>
    public class ManagerServices : IManagerServices
    {
        private readonly HttpClient _httpClient;
        public ManagerServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ConfigScenarioType>> GetConfigScenarioTypes()
        {
            var url = "api/scenario/getscenariotypes";
            var configScenarioTypes = await _httpClient.GetFromJsonAsync<IEnumerable<ConfigScenarioType>>(url);
            return configScenarioTypes;
        }

        public async Task<IEnumerable<AppUserViewModel>> GetAppUsers()
        {
            var url = "api/scenario/getappusers";
            var appUsers = await _httpClient.GetFromJsonAsync<IEnumerable<AppUserViewModel>>(url);
            return appUsers;
        }

        public async Task<IEnumerable<ScenarioManagerViewModel>> GetScenarioManagersAsync()
        {
            var url = "api/scenario/getallscenarios";
            var scenarioManagers = await _httpClient.GetFromJsonAsync<IEnumerable<ScenarioManagerViewModel>>(url);
            return scenarioManagers;
        }

        public async Task<int> CreateScenarioAsync(ScenarioDefinitionViewModel scenarioDefinitionViewModel)
        {
            var url = "api/scenario/createscenario";
            var response = await _httpClient.PostAsJsonAsync(url, scenarioDefinitionViewModel);

            if (response.IsSuccessStatusCode)
            {
                var id = await response.Content.ReadAsStringAsync();
                return int.Parse(id);
            }

            return 0;
        }

        public async Task<bool> RemoveScenarioAsync(int scenarioId)
        {
            var url = "api/scenario/removescenario";
            var response = await _httpClient.PostAsJsonAsync(url, scenarioId);
            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }

        public async Task<bool> UndoScenarioAsync(int scenarioId)
        {
            var url = "api/scenario/undoscenario";
            var response = await _httpClient.PostAsJsonAsync(url, scenarioId);
            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }

        public async Task<bool> DeleteScenarioAsync(int scenarioId)
        {
            var url = "api/scenario/deletescenario";
            var response = await _httpClient.PostAsJsonAsync(url, scenarioId);
            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }
    }
}
