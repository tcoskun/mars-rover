using MarsRover.Core.Aggregates;
using MarsRover.Core.Enums;
using NUnit.Framework;
using System;

namespace MarsRover.Test
{
    public class RoverTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void when_rover_input_is_invalid_then_throw_exception()
        {
            Assert.Throws<ArgumentException>(() => new Rover("5"));
            Assert.Throws<ArgumentException>(() => new Rover(string.Empty));
        }

        [Test]
        public void when_rover_input_is_valid_then_rover_position_is_available()
        {
            var rover = new Rover("5 3 N");

            Assert.AreEqual(5, rover.XPosition);
            Assert.AreEqual(3, rover.YPosition);
            Assert.AreEqual(Direction.N, rover.Direction);
        }
    }
}