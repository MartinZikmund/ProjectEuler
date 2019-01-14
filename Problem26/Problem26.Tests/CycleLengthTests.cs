using System;
using Xunit;

namespace Problem26.Tests
{
    public class CycleLengthTests
    {
        [Fact]
        public void Cycle3()
        {
            var length = new DecimalCycleLengthCalculator();
            Assert.Equal(1, length.CalculateCycleLength(3));
        }

        [Fact]
        public void Cycle7()
        {
            var length = new DecimalCycleLengthCalculator();
            Assert.Equal(6, length.CalculateCycleLength(7));
        }

        [Fact]
        public void Cycle6()
        {
            var length = new DecimalCycleLengthCalculator();
            Assert.Equal(1, length.CalculateCycleLength(6));
        }

        [Fact]
        public void Cycle2()
        {
            var length = new DecimalCycleLengthCalculator();
            Assert.Equal(0, length.CalculateCycleLength(2));
        }
    }
}
