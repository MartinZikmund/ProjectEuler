using System;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace Problem12.Tests
{
    public class ProblemTests
    {
        [Fact]
        public void OneHasOneDivisor()
        {
            Assert.Equal(1,new Problem12().CalculateNumberOfDivisors(1));
        }

        [Fact]
        public void DivisorsOf3()
        {
            Assert.Equal(2, new Problem12().CalculateNumberOfDivisors(3));
        }

        [Fact]
        public void DivisorsOf6()
        {
            Assert.Equal(4, new Problem12().CalculateNumberOfDivisors(6));
        }

        [Fact]
        public void DivisorsOf10()
        {
            Assert.Equal(4, new Problem12().CalculateNumberOfDivisors(10));
        }

        [Fact]
        public void DivisorsOf15()
        {
            Assert.Equal(4, new Problem12().CalculateNumberOfDivisors(15));
        }

        [Fact]
        public void DivisorsOf21()
        {
            Assert.Equal(4, new Problem12().CalculateNumberOfDivisors(21));
        }

        [Fact]
        public void DivisorsOf28()
        {
            Assert.Equal(6, new Problem12().CalculateNumberOfDivisors(28));
        }
    }
}
