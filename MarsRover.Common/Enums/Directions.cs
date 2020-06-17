using System.ComponentModel;

namespace MarsRover.Common.Enums
{
    public enum Directions
    {
        NAN = -1,
        [Description("W")]
        W = 0,
        [Description("N")]
        N = 1,
        [Description("E")]
        E = 2,
        [Description("S")]
        S = 3

    }
}