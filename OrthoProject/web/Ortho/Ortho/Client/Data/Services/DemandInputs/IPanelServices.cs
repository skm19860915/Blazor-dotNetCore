using Ortho.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ortho.Client.Data.Services.DemandInputs
{
    public interface IPanelServices
    {
        Task<IEnumerable<PanelAssayViewModel>> GetAllAssaysAsync();
        Task<IEnumerable<PanelViewModel>> GetPermanentPanelsAsync();
        Task<IEnumerable<PanelViewModel>> GetUserDefinedPanelsAsync(int userId);
        Task<bool> DeletePanelAsync(int panelId);
        Task<bool> UpdatePanelAsync(PanelViewModel panelViewModel);
    }
}
