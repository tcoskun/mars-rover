using MarsRover.Core.Enums;
using System;

namespace MarsRover.Core.Abstraction
{
    public interface IRover
    {
        public Guid Id { get; }
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public Direction Direction { get; set; }
    }
}
