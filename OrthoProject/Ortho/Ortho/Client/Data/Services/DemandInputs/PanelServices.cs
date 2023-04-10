using Ortho.Shared.Models;
using Ortho.Shared.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Ortho.Client.Data.Services.DemandInputs
{
    /// <summary>
    /// Panel & Assay Mamangement Service
    /// </summary>
    public class PanelServices : IPanelServices
    {
        private readonly HttpClient _httpClient;
        public PanelServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<PanelAssayViewModel>> GetAllAssaysAsync()
        {
            var url = "api/demandinputs/getallassays";
            var allAssays = await _httpClient.GetFromJsonAsync<IEnumerable<PanelAssayViewModel>>(url);
            return allAssays;
        }

        public async Task<IEnumerable<PanelViewModel>> GetPermanentPanelsAsync()
        {
            var url = "api/demandinputs/getpermanentpanels";
            var permanentPanels = await _httpClient.GetFromJsonAsync<IEnumerable<PanelViewModel>>(url);
            return permanentPanels;
        }

        public async Task<IEnumerable<PanelViewModel>> GetUserDefinedPanelsAsync(int userId)
        {
            var url = "api/demandinputs/getuserdefinedpanels/" + userId;
            var userDefinedPanels = await _httpClient.GetFromJsonAsync<IEnumerable<PanelViewModel>>(url);
            return userDefinedPanels;
        }

        public async Task<bool> DeletePanelAsync(int panelId)
        {
            var url = "api/demandinputs/deletepanel";
            var response = await _httpClient.PostAsJsonAsync(url, panelId);
            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }

        public async Task<bool> UpdatePanelAsync(PanelViewModel panelViewModel)
        {
            var url = "api/demandinputs/updatepanel";
            var response = await _httpClient.PostAsJsonAsync(url, panelViewModel);
            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }
    }
}
