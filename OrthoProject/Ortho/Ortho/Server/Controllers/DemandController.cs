using Microsoft.AspNetCore.Mvc;
using Ortho.Server.DALs.IProviders;
using Ortho.Shared.Models;
using Ortho.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ortho.Server.Controllers
{
    [Route("api/demandinputs")]
    [ApiController]
    public class DemandController : ControllerBase
    {
        private readonly IDemandProvider _provider;

        public DemandController(IDemandProvider provider)
        {
            _provider = provider;
        }

        [HttpGet("getallassays")]
        public async Task<IActionResult> GetAllAssaysAsync()
        {
            var configOrthoAssays = await _provider.GetAllAssaysAsync();
            return Ok(configOrthoAssays);
        }

        [HttpGet("getpermanentpanels")]
        public async Task<IActionResult> GetPermanentPanelsAsync()
        {
            var panels = await _provider.GetPermanentPanelsAsync();
            return Ok(panels);
        }

        [HttpGet("getuserdefinedpanels/{userId}")]
        public async Task<IActionResult> GetUserDefinedPanelsAsync(int userId)
        {
            var panels = await _provider.GetUserDefinedPanelsAsync(userId);
            return Ok(panels);
        }

        [HttpPost("deletepanel")]
        public async Task<IActionResult> DeletePanelAsync([FromBody] int panelId)
        {
            var success = await _provider.DeletePanelAsync(panelId);
            if (success == true)
                return Ok();

            return NotFound();
        }

        [HttpPost("updatepanel")]
        public async Task<IActionResult> UpdatePanelAsync([FromBody] PanelViewModel panelViewModel)
        {
            var success = await _provider.UpdatePanelAsync(panelViewModel);
            if (success == true)
                return Ok();

            return NotFound();
        }

        [HttpGet("getlisfileandcolumnmappings/{userId}/{customerId}")]
        public async Task<IActionResult> GetLISFileAndColumnMappingsAsync(int userId, int customerId)
        {
            var lisFileAndColumnMappings = await _provider.GetLISFileAndColumnMappingsAsync(userId, customerId);
            return Ok(lisFileAndColumnMappings);
        }

        [HttpPost("createlisfilemappingdata")]
        public async Task<IActionResult> CreateLISFileMappingDataAsync([FromBody] LISDataPostViewModel lisDataPostViewModel)
        {
            var success = await _provider.CreateLISFileMappingDataAsync(lisDataPostViewModel);
            if (success == true)
                return Ok();

            return NotFound();
        }

        [HttpPost("updatefilecolumnmapping")]
        public async Task<IActionResult> UpdateFileColumnMappingAsync([FromBody] List<DemandFileColumnMapping> fileColumnMappings)
        {
            var success = await _provider.UpdateFileColumnMappingAsync(fileColumnMappings);
            if (success == true)
                return Ok();

            return NotFound();
        }

        [HttpGet("getalldemandlisfiles")]
        public async Task<IActionResult> GetAllDemandLisFilesAsync()
        {
            var panels = await _provider.GetAllDemandLisFilesAsync();
            return Ok(panels);
        }
    }
}
