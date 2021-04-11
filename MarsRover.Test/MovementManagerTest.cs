using MarsRover.Core;
using MarsRover.Core.Aggregates;
using MarsRover.Core.Enums;
using NUnit.Framework;
using System.Collections.Generic;

namespace MarsRover.Test
{
    public class MovementManagerTest
    {
        private Plateau _plateau = default;
        private Rover _rover1 = default;
        private Rover _rover2 = default;
        private MovementManager _movementManager = default;

        [SetUp]
        public void Setup()
        {
            _plateau = new Plateau("5 5");
            _rover1 = new Rover("1 2 N");
            _rover2 = new Rover("3 3 E");
            _plateau.AddRover(_rover1);
            _plateau.AddRover(_rover2);
        }

        [Test]
        public void if_command_is_M_and_rover_direction_N_then_rover_moves_y_axis()
        {
            var roverCommands = new List<RoverCommand>
            {
                new RoverCommand(_rover1.Id, 1, "M")
            };

            _movementManager = new MovementManager(_plateau, roverCommands);
            _movementManager.StartMovements();

            Assert.AreEqual(1, _movementManager.Plateau.Rovers[0].XPosition);
            Assert.AreEqual(3, _movementManager.Plateau.Rovers[0].YPosition);
        }

        [Test]
        public void if_command_is_R_Or_L_then_rover_direction_chnages_but_position_does_not_change()
        {
            var roverCommands = new List<RoverCommand>
            {
                new RoverCommand(_rover1.Id, 1, "R"),
                new RoverCommand(_rover2.Id, 2, "L")
            };

            _movementManager = new MovementManager(_plateau, roverCommands);
            _movementManager.StartMovements();

            Assert.AreEqual(1, _movementManager.Plateau.Rovers[0].XPosition);
            Assert.AreEqual(2, _movementManager.Plateau.Rovers[0].YPosition);
            Assert.AreEqual(Direction.E, _movementManager.Plateau.Rovers[0].Direction);
            Assert.AreEqual(3, _movementManager.Plateau.Rovers[1].XPosition);
            Assert.AreEqual(3, _movementManager.Plateau.Rovers[1].YPosition);
            Assert.AreEqual(Direction.N, _movementManager.Plateau.Rovers[1].Direction);
        }

        [Test]
        public void rovers_move_with_commands()
        {
            var roverCommands = new List<RoverCommand>
            {
                new RoverCommand(_rover1.Id, 1, "LMLMLMLMM"),
                new RoverCommand(_rover2.Id, 2, "MMRMMRMRRM")
            };

            _movementManager = new MovementManager(_plateau, roverCommands);
            _movementManager.StartMovements();

            var updateRover1 = _movementManager.Plateau.Rovers[0];
            var updatedRover2 = _movementManager.Plateau.Rovers[1];
            Assert.AreEqual("1 3 N", $"{updateRover1.XPosition} {updateRover1.YPosition} {updateRover1.Direction}");
            Assert.AreEqual("5 1 E", $"{updatedRover2.XPosition} {updatedRover2.YPosition} {updatedRover2.Direction}");
        }
    }
}

