using Microsoft.AspNetCore.Mvc;
using Ortho.Server.DALs.IProviders;
using Ortho.Shared.Mappings;
using Ortho.Shared.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ortho.Server.Controllers
{
    /// <summary>
    /// Dedicated Scenario API
    /// </summary>
    [Route("api/scenario")]
    [ApiController]
    public class ScenarioController : ControllerBase
    {
        private readonly IScenarioProvider _provider;

        public ScenarioController(IScenarioProvider provider)
        {
            _provider = provider;
        }

        [HttpGet("getdemandsources")]
        public async Task<IActionResult> GetConfigDemandSourcesAsync()
        {
            var configDemandSources = await _provider.GetConfigDemandSourcesAsync();
            return Ok(configDemandSources);
        }

        [HttpGet("getlabtypes")]
        public async Task<IActionResult> GetConfigLabTypesAsync()
        {
            var configLabTypes = await _provider.GetConfigLabTypesAsync();
            return Ok(configLabTypes);
        }

        [HttpGet("getscenariotypes")]
        public async Task<IActionResult> GetConfigScenarioTypesAsync()
        {
            var configScenarioTypes = await _provider.GetConfigScenarioTypesAsync();
            return Ok(configScenarioTypes);
        }

        [HttpGet("getappusers")]
        public async Task<IActionResult> GetAppUsersAsync()
        {
            var appUsers = await _provider.GetAppUsersAsync();
            return Ok(appUsers);
        }

        [HttpGet("getextcustomers")]
        public async Task<IActionResult> GetExtCustomersAsync()
        {
            var extCustomers = await _provider.GetExtCustomersAsync();
            return Ok(extCustomers);
        }

        [HttpGet("getallscenarios")]
        public async Task<IActionResult> GetScenariosAsync()
        {
            var scenarioManagers = await _provider.GetScenarioManagersAsync();
            return Ok(scenarioManagers);
        }

        [HttpPost("createscenario")]
        public async Task<IActionResult> CreateScenarioAsync([FromBody] ScenarioDefinitionViewModel scenarioDefinitionViewModel)
        {
            var newScenarioId = await _provider.CreateScenarioAsync(scenarioDefinitionViewModel);
            if (newScenarioId > 0)
                return Ok(newScenarioId);

            return NotFound();
        }

        [HttpPost("removescenario")]
        public async Task<IActionResult> RemoveScenarioAsync([FromBody] int scenarioId)
        {
            var success = await _provider.RemoveScenarioAsync(scenarioId);
            if (success == true)
                return Ok();

            return NotFound();
        }

        [HttpPost("undoscenario")]
        public async Task<IActionResult> UndoScenarioAsync([FromBody] int scenarioId)
        {
            var success = await _provider.UndoScenarioAsync(scenarioId);
            if (success == true)
                return Ok();

            return NotFound();
        }

        [HttpPost("deletescenario")]
        public async Task<IActionResult> DeleteScenarioAsync([FromBody] int scenarioId)
        {
            var success = await _provider.DeleteScenarioAsync(scenarioId);
            if (success == true)
                return Ok();

            return NotFound();
        }

        [HttpGet("getscenario/{scenarioId}")]
        public async Task<IActionResult> GetScenarioAsync(string scenarioId)
        {
            var scenarios = await _provider.GetScenariosAsync();
            var scenario = scenarios.FirstOrDefault(s => s.scenarioId == Convert.ToInt32(scenarioId));
            var scenarioDefintion = scenario.ToScenarioDefinitionViewModel();
            return Ok(scenarioDefintion);
        }

        [HttpPost("updatescenario")]
        public async Task<IActionResult> UpdateScenarioAsync([FromBody] ScenarioDefinitionViewModel scenarioDefinitionViewModel)
        {
            var result = await _provider.UpdateScenarioAsync(scenarioDefinitionViewModel);
            if (result == true)
                return Ok();

            return NotFound();
        }

        [HttpPost("createextcustomer")]
        public async Task<IActionResult> CreateExtCustomerAsync([FromBody] ScenarioDefinitionViewModel scenarioDefinitionViewModel)
        {
            var newCustomerId = await _provider.CreateCustomerAsync(scenarioDefinitionViewModel);
            if (newCustomerId > 0)
                return Ok();

            return NotFound();
        }
    }
}
