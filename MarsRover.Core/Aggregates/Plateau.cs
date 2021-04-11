using MarsRover.Core.Abstraction;
using MarsRover.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Core.Aggregates
{
    public class Plateau
    {
        public int Width { get; }
        public int Height { get; }
        public IList<IRover> Rovers { get; private set; }

        public Plateau(string plateauInput)
        {
            Rovers = new List<IRover>();
            if (!string.IsNullOrEmpty(plateauInput))
            {
                var sizeArray = plateauInput.Split(" ");
                if(sizeArray.Length == 2)
                {
                    int.TryParse(sizeArray[0], out int width);
                    int.TryParse(sizeArray[1], out int height);

                    if (width == 0 || height == 0)
                    {
                        throw new ArgumentException("Plateau size is invalid!");
                    }

                    Width = width;
                    Height = height;
                }
                else
                {
                    throw new ArgumentException("Plateau size count is invalid!");
                }
            }
            else 
            {
                throw new ArgumentException("Plateau size input is empty!");
            }

        }

        public void AddRover(IRover rover)
        {
            if (rover.XPosition > Width)
            {
                throw new ArgumentException("X position is out of the plateau size!");
            }

            if (rover.YPosition > Height)
            {
                throw new ArgumentException("Y position is out of the plateau size!");
            }

            Rovers.Add(rover);
        }

        public void ReLocateRover(Guid roverId, int xPosition, int yPosition, Direction direction)
        {
            var currentRover = Rovers.FirstOrDefault(r => r.Id == roverId);

            if(currentRover != null)
            {
                currentRover.XPosition = xPosition;
                currentRover.YPosition = yPosition;
                currentRover.Direction = direction;
            }
        }
    }
}
