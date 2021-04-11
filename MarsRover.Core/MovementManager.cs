using MarsRover.Core.Abstraction;
using MarsRover.Core.Aggregates;
using MarsRover.Core.Enums;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Core
{
    public class MovementManager
    {
        public Plateau Plateau { get; private set; }
        public IList<RoverCommand> RoverCommands { get; }

        public MovementManager(Plateau plateau, IList<RoverCommand> roverCommands)
        {
            Plateau = plateau;
            RoverCommands = roverCommands;
        }

        public void StartMovements()
        {
            foreach(var roverCommand in  RoverCommands.OrderBy(r => r.Order))
            {
                var rover = Plateau.Rovers.FirstOrDefault(r => r.Id == roverCommand.RoverId);

                if(rover != null)
                {
                    rover = StartRoverMovements(rover, roverCommand.MovementList);
                    Plateau.ReLocateRover(rover.Id, rover.XPosition, rover.YPosition, rover.Direction);
                }
            }
        }

        #region private methods
        
        private IRover StartRoverMovements(IRover rover, IList<Movement> movements)
        {
            foreach(var movement in movements)
            {
                switch (movement)
                {
                    case Movement.L:
                        rover.Direction = TurnLeft(rover.Direction);
                        break;
                    case Movement.R:
                        rover.Direction = TurnRight(rover.Direction);
                        break;
                    case Movement.M:
                        rover = MoveRover(rover);
                        break;
                }
            }

            return rover;
        }

        private Direction TurnLeft(Direction currentDirection)
        {
            var newDirection = Direction.N;

            switch (currentDirection)
            {
                case Direction.N:
                    newDirection = Direction.W;
                    break;
                case Direction.E:
                    newDirection = Direction.N;
                    break;
                case Direction.S:
                    newDirection = Direction.E;
                    break;
                case Direction.W:
                    newDirection = Direction.S;
                    break;
            }

            return newDirection;
        }

        private Direction TurnRight(Direction currentDirection)
        {
            var newDirection = Direction.N;

            switch (currentDirection)
            {
                case Direction.N:
                    newDirection = Direction.E;
                    break;
                case Direction.E:
                    newDirection = Direction.S;
                    break;
                case Direction.S:
                    newDirection = Direction.W;
                    break;
                case Direction.W:
                    newDirection = Direction.N;
                    break;
            }

            return newDirection;
        }

        private IRover MoveRover(IRover rover)
        {
            switch (rover.Direction)
            {
                case Direction.N:
                    if(rover.YPosition < Plateau.Height)
                    {
                        rover.YPosition++;
                    }
                    break;
                case Direction.E:
                    if (rover.XPosition < Plateau.Width)
                    {
                        rover.XPosition++;
                    }
                    break;
                case Direction.S:
                    if (rover.YPosition > 0)
                    {
                        rover.YPosition--;
                    }
                    break;
                case Direction.W:
                    if (rover.XPosition > 0)
                    {
                        rover.XPosition--;
                    }
                    break;
            }

            return rover;
        }

        #endregion
    }
}
