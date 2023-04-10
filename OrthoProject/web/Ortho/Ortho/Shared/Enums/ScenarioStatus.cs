using System.ComponentModel;

namespace Ortho.Shared.Enums
{
    public enum ScenarioStatus
    {
        [Description("In Progress")]
        InProgress = 1,
        [Description("Run Complete")]
        RunComplete,
        [Description("Published")]
        Published
    }
}
