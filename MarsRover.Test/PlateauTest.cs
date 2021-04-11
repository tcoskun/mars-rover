using MarsRover.Core.Aggregates;
using NUnit.Framework;
using System;

namespace MarsRover.Test
{
    public class PlateauTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void when_plateau_input_is_invalid_then_throw_exception()
        {
            Assert.Throws<ArgumentException>(() => new Plateau("5"));
            Assert.Throws<ArgumentException>(() => new Plateau(string.Empty));
        }

        [Test]
        public void when_plateau_input_is_valid_then_size_is_greater_than_0()
        {
            var plateau = new Plateau("5 5");

            Assert.Greater(plateau.Height, 0);
            Assert.Greater(plateau.Width, 0);
        }
    }
}