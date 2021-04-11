using MarsRover.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Core.Aggregates
{
    public class RoverCommand
    {
        public Guid RoverId { get; }
        public int Order { get; }
        public IList<Movement> MovementList { get; }

        public RoverCommand(Guid roverId, int order, string roverMovementInput)
        {
            RoverId = roverId;
            Order = order;
            MovementList = new List<Movement>();

            if (!string.IsNullOrEmpty(roverMovementInput))
            {
                var inputArray = roverMovementInput.ToCharArray();
                MovementList = inputArray.Select(input =>
                {
                    Enum.TryParse(input.ToString(), out Movement movement);
                    return movement;
                }).ToList();
            }
        }
    }
}
