using Ortho.Shared.Models;
using Ortho.Shared.ViewModels;
using System;

namespace Ortho.Shared.Mappings
{
    public static class ScenairoDefinitionMapping
    {
        public static ScenarioDefinitionViewModel ToScenarioDefinitionViewModel(this Scenario scenario)
        {
            return new ScenarioDefinitionViewModel
            {
                Id = scenario.scenarioId,
                ScenarioTypeId = scenario.scenarioTypeId,
                ScenarioType = scenario.configScenarioType.scenarioType,
                CreationDate = scenario.creationDt.ToString("MM/dd/yyyy"),
                CreatorId = scenario.userIdCreator,
                Creator = scenario.userCreator.firstName + " " + scenario.userCreator.lastName,
                OwnerId = scenario.userIdOwner,
                Owner = scenario.userOwner.firstName + " " + scenario.userOwner.lastName,
                OwnerTitle = scenario.userOwner.title,
                NickName = scenario.nickname,
                Description = scenario.description,
                Mode = scenario.practice.Value,
                DemandSource = scenario.configDemandSource.demandSourceId,
                SfdcNumber = scenario.extCustomer.sfdcId,
                CustomerType = scenario.newCustomer,
                LabType = scenario.configLabType.labTypeId,
                CustomerId = scenario.customerId.Value,
                CustomerName = scenario.extCustomer.name,
                City = scenario.extCustomer.city,
                State = scenario.extCustomer.stateOrProvince,
                Country = scenario.extCustomer.country
            };
        }

        public static Scenario ToUpdatedScenario(this Scenario scenario, ScenarioDefinitionViewModel changes)
        {
            scenario.scenarioId = changes.Id;
            scenario.userIdOwner = changes.OwnerId;
            scenario.userIdCreator = changes.CreatorId;
            scenario.creationDt = DateTime.Parse(changes.CreationDate);
            scenario.nickname = changes.NickName;
            scenario.scenarioTypeId = changes.ScenarioTypeId;
            scenario.description = changes.Description;
            scenario.practice = changes.Mode;
            scenario.demandSource = changes.DemandSource;
            scenario.newCustomer = changes.CustomerType;
            scenario.customerId = changes.CustomerId;
            scenario.labTypeId = changes.LabType;

            return scenario;
        }

        public static ExtCustomer ToUpdatedCustomer(this ExtCustomer customer, ScenarioDefinitionViewModel changes)
        {
            customer.customerId = changes.CustomerId;
            customer.sfdcId = changes.SfdcNumber;
            customer.name = changes.CustomerName;
            customer.city = changes.City;
            customer.stateOrProvince = changes.State;
            customer.country = changes.Country;

            return customer;
        }
    }
}
