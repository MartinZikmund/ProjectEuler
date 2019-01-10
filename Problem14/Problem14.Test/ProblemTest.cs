using System;
using Xunit;

namespace Problem14.Test
{    
    public class ProblemTest
    {
        [Fact]
        public void ChainOf13Is10()
        {
            Assert.Equal(10, Solver.CalculateChainLength(13));
        }
    }
}
