using Ortho.Shared.Models;
using Ortho.Shared.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Ortho.Client.Data.Services.ScenarioDefinition
{
    /// <summary>
    /// Scenairo Definition Service
    /// </summary>
    public class ScenarioServices : IScenarioServices
    {
        private readonly HttpClient _httpClient;
        public ScenarioServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ConfigDemandSource>> GetConfigDemandSources()
        {
            var url = "api/scenario/getdemandsources";
            var configDemandSources = await _httpClient.GetFromJsonAsync<IEnumerable<ConfigDemandSource>>(url);
            return configDemandSources;
        }

        public async Task<IEnumerable<ConfigLabType>> GetConfigLabTypes()
        {
            var url = "api/scenario/getlabtypes";
            var configLabTypes = await _httpClient.GetFromJsonAsync<IEnumerable<ConfigLabType>>(url);
            return configLabTypes;
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

        public async Task<IEnumerable<ExtCustomer>> GetExtCustomersAsync()
        {
            var url = "api/scenario/getextcustomers";
            var extCustomers = await _httpClient.GetFromJsonAsync<IEnumerable<ExtCustomer>>(url);
            return extCustomers;
        }

        public async Task<ScenarioDefinitionViewModel> GetScenarioDefintionAsync(string scenarioId)
        {
            var url = "api/scenario/getscenario/" + scenarioId;
            var scenarioDefinition = await _httpClient.GetFromJsonAsync<ScenarioDefinitionViewModel>(url);
            return scenarioDefinition;
        }

        public async Task<bool> SaveActionAsync(ScenarioDefinitionViewModel scenarioDefinition)
        {
            if(scenarioDefinition.CustomerId == 0)
            {
                var status = await CreateCustomerAsync(scenarioDefinition);
                return status;
            }

            if(scenarioDefinition.Id == 0)
            {
                await CreateScenarioAsync(scenarioDefinition);
            }

            var url = "api/scenario/updatescenario";
            var response = await _httpClient.PostAsJsonAsync(url, scenarioDefinition);
            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }

        public async Task<bool> CreateCustomerAsync(ScenarioDefinitionViewModel scenarioDefinition)
        {
            var url = "api/scenario/createextcustomer";
            var response = await _httpClient.PostAsJsonAsync(url, scenarioDefinition);
            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }

        public async Task<bool> CreateScenarioAsync(ScenarioDefinitionViewModel scenarioDefinition)
        {
            var url = "api/scenario/createscenario";
            var response = await _httpClient.PostAsJsonAsync(url, scenarioDefinition);
            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }
    }
}
