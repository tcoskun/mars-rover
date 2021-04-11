using MarsRover.Core.Abstraction;
using MarsRover.Core.Enums;
using System;

namespace MarsRover.Core.Aggregates
{
    public class Rover: IRover
    {
        public Guid Id { get; }
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public Direction Direction { get; set; }

        public Rover(string roverInput)
        {
            Id = Guid.NewGuid();

            if (!string.IsNullOrEmpty(roverInput))
            {
                var inputArray = roverInput.Split(" ");
                if (inputArray.Length == 3)
                {
                    int.TryParse(inputArray[0], out int xPosition);
                    int.TryParse(inputArray[1], out int yPosition);
                    Enum.TryParse(inputArray[2], out Direction direction);

                    XPosition = xPosition;
                    YPosition = yPosition;
                    Direction = direction;
                } 
                else
                {
                    throw new ArgumentException("Rover position count is invalid!");
                }
            }
            else
            {
                throw new ArgumentException("Rover position input is empty!");
            }
        }
    }
}
