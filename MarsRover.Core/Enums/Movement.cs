using System.ComponentModel;

namespace MarsRover.Core.Enums
{
    public enum Movement
    {
        [Description("None")]
        N = 0,
        [Description("Left")]
        L = 1,
        [Description("Right")]
        R = 2,
        [Description("Move")]
        M = 3,
    }
}
