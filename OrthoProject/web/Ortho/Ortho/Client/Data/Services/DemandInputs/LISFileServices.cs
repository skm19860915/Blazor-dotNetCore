using Ortho.Shared.Enums;
using Ortho.Shared.Models;
using Ortho.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Ortho.Client.Data.Services.DemandInputs
{
    /// <summary>
    /// LIS information Drag & Drop control Service
    /// </summary>
    public class LISFileServices : ILISFileServices
    {
        private readonly HttpClient _httpClient;
        public string Data { get; set; }
        public ConfigLisField Zone { get; set; }

        public LISFileServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void StartDrag(string data, ConfigLisField zone)
        {
            Data = data;
            Zone = zone;
        }

        public bool Accepts(ConfigLisField zone)
        {
            return Zone == zone;
        }

        public async Task<IEnumerable<LISFileAndColumnMappingViewModel>> GetLISFileAndColumnMappingsAsync(int userId, int customerId)
        {
            var url = "api/demandinputs/getlisfileandcolumnmappings/" + userId + "/" + customerId;
            var lisFileAndColumnMappings = await _httpClient.GetFromJsonAsync<IEnumerable<LISFileAndColumnMappingViewModel>>(url);
            return lisFileAndColumnMappings;
        }

        public async Task<int> SaveActionAsync(LISFilePostViewModel lisFilePostViewModel)
        {
            var url = "api/demandinputs/createlisfile";
            var response = await _httpClient.PostAsJsonAsync(url, lisFilePostViewModel);
            if (response.IsSuccessStatusCode)
            {
                var value = response.Content.ReadAsStringAsync().Result;
                return Convert.ToInt32(value);
            }
                
            return 0;
        }

        public async Task<bool> UpdateFileColumnMappingAsync(List<DemandFileColumnMapping> fileColumnMappings)
        {
            var url = "api/demandinputs/updatefilecolumnmapping";
            var response = await _httpClient.PostAsJsonAsync(url, fileColumnMappings);
            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }

        public async Task<List<DemandLISFileViewModel>> GetAllDemandLisFilesAsync()
        {
            var url = "api/demandinputs/getalldemandlisfiles";
            var allDemandLisFiles = await _httpClient.GetFromJsonAsync<List<DemandLISFileViewModel>>(url);
            return allDemandLisFiles;
        }

        public async Task<bool> CheckScenarioWithLISFileAsync(int lisFileId)
        {
            var url = "api/demandinputs/checkscenariowithlisfile/" + lisFileId;
            var isFoundScenario = await _httpClient.GetFromJsonAsync<bool>(url);
            return isFoundScenario;
        }
    }
}
