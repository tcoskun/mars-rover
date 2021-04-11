using MarsRover.Core.Aggregates;
using MarsRover.Core.Enums;
using NUnit.Framework;
using System;

namespace MarsRover.Test
{
    public class RoverCommandTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void when_rover_command_input_is_valid_then_rover_command_is_available()
        {
            var roverId = Guid.NewGuid();
            var roverOrder = 1;
            var roverCommand = new RoverCommand(roverId, roverOrder, "MMRL");

            Assert.AreEqual(roverId, roverCommand.RoverId);
            Assert.AreEqual(roverOrder, roverCommand.Order);
            Assert.AreEqual(4, roverCommand.MovementList.Count);
            Assert.AreEqual(Movement.M, roverCommand.MovementList[0]);
            Assert.AreEqual(Movement.M, roverCommand.MovementList[1]);
            Assert.AreEqual(Movement.R, roverCommand.MovementList[2]);
            Assert.AreEqual(Movement.L, roverCommand.MovementList[3]);
        }
    }
}
