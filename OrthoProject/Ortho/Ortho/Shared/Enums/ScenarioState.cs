using System.ComponentModel;

namespace Ortho.Shared.Enums
{
    public enum ScenarioState
    {
        [Description("Active")]
        Active = 1,
        [Description("Archived")]
        Archived,
        [Description("Deleted")]
        Deleted
    }
}
