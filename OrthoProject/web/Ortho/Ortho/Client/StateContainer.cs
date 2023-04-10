using Ortho.Shared.ViewModels;
using System;

namespace Ortho.Client
{
    /// <summary>
    /// State Managment Service
    /// </summary>
    public class StateContainer
    {
        private bool IsAuthenticated;
        private ScenarioDefinitionViewModel ScenarioDefinitionViewModel;
        private bool IsScenarioDefinitionChanged;
        private bool ShowNavBar;
        private string CurrentScenarioId;
        private bool IsEmptyScenarioNickName;
        private bool IsEmptyScenarioDescription;
        private bool IsEmptySFDCNumber;
        private bool IsEmptyCustomerName;
        private bool IsEmptyCity;
        private bool IsEmptyStateProvince;
        private bool IsEmptyCountry;

        public string ScenarioId
        {
            get => CurrentScenarioId;
            set
            {
                CurrentScenarioId = value;
                NotifyStateChanged();
            }
        }
        public bool ActiveNavBar
        {
            get => ShowNavBar;
            set
            {
                ShowNavBar = value;
                NotifyStateChanged();
            }
        }
        public bool AuthenticationVerified
        {
            get => IsAuthenticated;
            set
            {
                IsAuthenticated = value;
                NotifyStateChanged();
            }
        }
        public ScenarioDefinitionViewModel ScenarioDefinitionObj
        {
            get => ScenarioDefinitionViewModel;
            set
            {
                ScenarioDefinitionViewModel = value;
                NotifyStateChanged();
            }
        }
        public bool ScenarioDefinitionChanged
        {
            get => IsScenarioDefinitionChanged;
            set
            {
                IsScenarioDefinitionChanged = value;
                NotifyStateChanged();
            }
        }

        public bool EmptyScenarioNickName
        {
            get => IsEmptyScenarioNickName;
            set
            {
                IsEmptyScenarioNickName = value;
                NotifyStateChanged();
            }
        }

        public bool EmptyScenarioDescription
        {
            get => IsEmptyScenarioDescription;
            set
            {
                IsEmptyScenarioDescription = value;
                NotifyStateChanged();
            }
        }

        public bool EmptySFDCNumber
        {
            get => IsEmptySFDCNumber;
            set
            {
                IsEmptySFDCNumber = value;
                NotifyStateChanged();
            }
        }

        public bool EmptyCustomerName
        {
            get => IsEmptyCustomerName;
            set
            {
                IsEmptyCustomerName = value;
                NotifyStateChanged();
            }
        }

        public bool EmptyCity
        {
            get => IsEmptyCity;
            set
            {
                IsEmptyCity = value;
                NotifyStateChanged();
            }
        }

        public bool EmptyStateProvince
        {
            get => IsEmptyStateProvince;
            set
            {
                IsEmptyStateProvince = value;
                NotifyStateChanged();
            }
        }

        public bool EmptyCountry
        {
            get => IsEmptyCountry;
            set
            {
                IsEmptyCountry = value;
                NotifyStateChanged();
            }
        }

        public event Action OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
