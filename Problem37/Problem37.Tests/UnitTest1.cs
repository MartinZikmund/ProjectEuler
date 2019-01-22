using System;
using Xunit;

namespace Problem37.Tests
{
    public class Problem37Tests
    {
        [Fact]
        public void CanCutOffEnd()
        {
            Assert.Equal(5, new Solver().CutEnd(59));
        }

        [Fact]
        public void SingleDigit()
        {
            Assert.Equal(0, new Solver().CutEnd(3));
        }

        [Fact]
        public void SingleDigitStart()
        {
            Assert.Equal(0, new Solver().CutStart(3));
        }

        [Fact]
        public void CanCutOffStart()
        {
            Assert.Equal(1233, new Solver().CutStart(61233));
        }
    }
}
