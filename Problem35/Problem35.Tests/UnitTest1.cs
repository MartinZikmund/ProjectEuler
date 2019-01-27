using System;
using Xunit;

namespace Problem35.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void OneDigitRotate()
        {
            Assert.Equal(8, new Solver().GetNextRotation(8));
        }

        [Fact]
        public void TwoDigitRotate()
        {
            Assert.Equal(36, new Solver().GetNextRotation(63));
        }

        [Fact]
        public void ThreeDigitRotate()
        {
            Assert.Equal( 451, new Solver().GetNextRotation(514));
        }
    }
}
