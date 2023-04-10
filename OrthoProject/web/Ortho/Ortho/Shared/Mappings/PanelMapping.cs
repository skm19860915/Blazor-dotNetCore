using Ortho.Shared.Models;
using Ortho.Shared.ViewModels;
using System.Linq;

namespace Ortho.Shared.Mappings
{
    public static class PanelMapping
    {
        public static PanelViewModel ToPanelViewModel(this Panel panel)
        {
            return new PanelViewModel
            {
                Id = panel.panelId,
                PanelName = panel.name,
                PanelAssays = panel.panelAssays.Select(p => p.ToPanelAssayViewModel()).ToList()
            };
        }

        public static PanelAssayViewModel ToPanelAssayViewModel(this PanelAssay panelAssay)
        {
            return new PanelAssayViewModel
            {
                AssayId = panelAssay.assay.assayId,
                AssayName = panelAssay.assay.name
            };
        }

        public static PanelAssayViewModel ToPanelAssayViewModelWithConfigOrthoAssay(this ConfigOrthoAssay configOrthoAssay)
        {
            return new PanelAssayViewModel
            {
                AssayId = configOrthoAssay.assayId,
                AssayName = configOrthoAssay.name
            };
        }

        public static PanelAssay ToPanelAssay(this PanelAssayViewModel panelAssayViewModel, int panelId)
        {
            return new PanelAssay
            {
                panelId = panelId,
                assayId=panelAssayViewModel.AssayId
            };
        }

        public static Panel ToPanel(this PanelViewModel panelViewModel)
        {
            return new Panel
            {
                name = panelViewModel.PanelName,
                userId = panelViewModel.UserId,
                global = false
            };
        }

        public static DemandLISFileViewModel ToDemandLISFileViewModel(this DemandLISFile demandLISFile)
        {
            return new DemandLISFileViewModel
            {
                LisSetId = demandLISFile.lisSetId,
                UserId = demandLISFile.userId,
                FileName = demandLISFile.fileName,
                CustomerId = demandLISFile.customerId
            };
        }
    }
}
