using Ortho.Shared.Enums;
using Ortho.Shared.Models;
using Ortho.Shared.ViewModels;
using System;

namespace Ortho.Shared.Mappings
{
    public static class ScenarioManagerMapping
    {
        public static ScenarioManagerViewModel ToScenarioManagerViewModel(this Scenario scenario)
        {
            return new ScenarioManagerViewModel
            {
                Id = scenario.scenarioId,
                CustomerId = scenario.customerId.Value,
                Customer = scenario.extCustomer?.name,
                ScenarioNickName = scenario.nickname,
                Number = scenario.extCustomer?.sfdcId,
                CreationDate = scenario.creationDt,
                OwnerId = scenario.userIdOwner,
                Owner = scenario.userOwner.firstName + " " + scenario.userOwner.lastName,
                TypeId = scenario.scenarioTypeId,
                Type = scenario.configScenarioType.scenarioType,
                Status = (ScenarioStatus)scenario.statusId,
                State = (ScenarioState)scenario.stateId
            };
        }

        public static Scenario ToNewScenario(this ScenarioDefinitionViewModel scenarioDefinitionViewModel)
        {
            return new Scenario
            {
                scenarioId = scenarioDefinitionViewModel.Id,
                userIdOwner = scenarioDefinitionViewModel.OwnerId,
                userIdCreator = scenarioDefinitionViewModel.CreatorId,
                creationDt = DateTime.Parse(scenarioDefinitionViewModel.CreationDate),
                nickname = scenarioDefinitionViewModel.NickName,
                statusId = (int)ScenarioStatus.InProgress,
                stateId = (int)ScenarioState.Active,
                scenarioTypeId = scenarioDefinitionViewModel.ScenarioTypeId,
                description = scenarioDefinitionViewModel.Description,
                practice = scenarioDefinitionViewModel.Mode,
                demandSource = scenarioDefinitionViewModel.DemandSource,
                newCustomer = true,
                customerId = scenarioDefinitionViewModel.CustomerId,
                labTypeId = scenarioDefinitionViewModel.LabType
            };
        }

        public static ExtCustomer ToNewCustomer(this ScenarioDefinitionViewModel scenarioDefinitionViewModel)
        {
            return new ExtCustomer
            {
                customerId = scenarioDefinitionViewModel.CustomerId,
                sfdcId = scenarioDefinitionViewModel.SfdcNumber,
                name = scenarioDefinitionViewModel.CustomerName,
                city = scenarioDefinitionViewModel.City,
                stateOrProvince = scenarioDefinitionViewModel.State,
                country = scenarioDefinitionViewModel.Country
            };
        }
    }
}
