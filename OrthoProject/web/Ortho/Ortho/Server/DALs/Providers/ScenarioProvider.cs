using Microsoft.EntityFrameworkCore;
using Ortho.Server.DALs.IProviders;
using Ortho.Shared.Enums;
using Ortho.Shared.Mappings;
using Ortho.Shared.Models;
using Ortho.Shared.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ortho.Server.DALs.Providers
{
    /// <summary>
    /// Scenario Information ServiceProvider
    /// </summary>
    public class ScenarioProvider : IScenarioProvider
    {
        private readonly OrthoDBContext _dbContext;
        public ScenarioProvider(OrthoDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<ConfigDemandSource>> GetConfigDemandSourcesAsync()
        {
            var configDemandSources = await _dbContext.configDemandSources.ToListAsync();
            return configDemandSources;
        }

        public async Task<List<ConfigLabType>> GetConfigLabTypesAsync()
        {
            var configLabTypes = await _dbContext.configLabTypes.ToListAsync();
            return configLabTypes;
        }

        public async Task<List<ConfigScenarioType>> GetConfigScenarioTypesAsync()
        {
            var configScenarioTypes = await _dbContext.configScenarioTypes.ToListAsync();
            return configScenarioTypes;
        }

        public async Task<List<AppUserViewModel>> GetAppUsersAsync()
        {
            var appUsers = await _dbContext.appUsers.ToListAsync();
            var users = appUsers.Select(a => a.ToUser()).ToList();
            return users;
        }

        public async Task<List<ExtCustomer>> GetExtCustomersAsync()
        {
            var extCustomers = await _dbContext.extCustomers.ToListAsync();
            return extCustomers;
        }

        public async Task<List<Scenario>> GetScenariosAsync()
        {
            var scenarios = await _dbContext.scenarios
                .Include(c => c.configLabType)
                .Include(d => d.configDemandSource)
                .Include(u => u.userCreator)
                .Include(o => o.userOwner)
                .Include(s => s.configScenarioType)
                .Include(cus => cus.extCustomer)
                .ToListAsync();

            return scenarios;
        }

        public async Task<IEnumerable<ScenarioManagerViewModel>> GetScenarioManagersAsync()
        {
            var scenarios = await GetScenariosAsync();
            var scenarioManagers = scenarios.Where(s => s.stateId == (int)ScenarioState.Active || s.stateId == (int)ScenarioState.Archived)
                .Select(s => s.ToScenarioManagerViewModel());
            return scenarioManagers;
        }

        public async Task<int> CreateScenarioAsync(ScenarioDefinitionViewModel scenarioDefinitionViewModel)
        {
            var scenarios = await _dbContext.scenarios.ToListAsync();
            var lastIndex = scenarios.OrderByDescending(s => s.scenarioId).First().scenarioId + 1;
            scenarioDefinitionViewModel.Id = lastIndex;

            var newScenario = scenarioDefinitionViewModel.ToNewScenario();
            try
            {
                _dbContext.Add(newScenario);
                await _dbContext.SaveChangesAsync();
                return lastIndex;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<bool> UpdateScenarioAsync(ScenarioDefinitionViewModel scenarioDefinitionViewModel)
        {
            var updated = await UpdateCustomerAsync(scenarioDefinitionViewModel);
            if(!updated)
                return false;

            var existing = await _dbContext.scenarios.FirstOrDefaultAsync(e => e.scenarioId == scenarioDefinitionViewModel.Id);
            if (existing == null)
                return false;

            var scenario = existing.ToUpdatedScenario(scenarioDefinitionViewModel);
            try
            {
                _dbContext.Update(scenario);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> RemoveScenarioAsync(int scenarioId)
        {
            var existing = await _dbContext.scenarios.FirstOrDefaultAsync(s => s.scenarioId == scenarioId);
            if(existing == null)
                return false;

            existing.stateId = (int)ScenarioState.Archived;
            try
            {
                _dbContext.Update(existing);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UndoScenarioAsync(int scenarioId)
        {
            var existing = await _dbContext.scenarios.FirstOrDefaultAsync(s => s.scenarioId == scenarioId);
            if (existing == null)
                return false;

            existing.stateId = (int)ScenarioState.Active;
            try
            {
                _dbContext.Update(existing);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteScenarioAsync(int scenarioId)
        {
            var existing = await _dbContext.scenarios.FirstOrDefaultAsync(s => s.scenarioId == scenarioId);
            if (existing == null)
                return false;

            existing.stateId = (int)ScenarioState.Deleted;
            try
            {
                _dbContext.Update(existing);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<int> CreateCustomerAsync(ScenarioDefinitionViewModel scenarioDefinitionViewModel)
        {
            var customers = await _dbContext.extCustomers.ToListAsync();
            var lastIndex = customers.OrderByDescending(c => c.customerId).First().customerId + 1;
            scenarioDefinitionViewModel.CustomerId = lastIndex;

            var newCustomer = scenarioDefinitionViewModel.ToNewCustomer();
            try
            {
                _dbContext.Add(newCustomer);
                await _dbContext.SaveChangesAsync();
                return lastIndex;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<bool> UpdateCustomerAsync(ScenarioDefinitionViewModel scenarioDefinitionViewModel)
        {
            var existing = await _dbContext.extCustomers.FirstOrDefaultAsync(e => e.customerId == scenarioDefinitionViewModel.CustomerId);
            if (existing == null)
                return false;

            var scenario = existing.ToUpdatedCustomer(scenarioDefinitionViewModel);
            try
            {
                _dbContext.Update(scenario);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
