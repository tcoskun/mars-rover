using System.ComponentModel;

namespace MarsRover.Core.Enums
{
    public enum Direction
    {
        [Description("None")]
        X = 0,
        [Description("North")]
        N = 1,
        [Description("East")]
        E = 2,
        [Description("South")]
        S = 3,
        [Description("West")]
        W = 4
    }
}
