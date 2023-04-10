using System.ComponentModel;

namespace Ortho.Shared.Enums
{
    public enum ScenarioType
    {
        [Description("Analyzer")]
        Analyzer = 1,
        [Description("Automation")]
        Automation,
        [Description("XT Counts")]
        XTCounts
    }
}
