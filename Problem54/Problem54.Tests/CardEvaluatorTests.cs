using System;
using Xunit;

namespace Problem54.Tests
{
    public class CardEvaluatorTests
    {
        [Fact]
        public void FirstSample()
        {
            var cardEvaluator = new CardEvaluator();
            var player1Score = cardEvaluator.Evaluate("5H 5C 6S 7S KD".Split(' '));
            var player2Score = cardEvaluator.Evaluate("2C 3S 8S 8D TD".Split(' '));
            Assert.True(player2Score > player1Score);
        }

        [Fact]
        public void SecondSample()
        {
            var cardEvaluator = new CardEvaluator();
            Assert.Equal(1, 
                cardEvaluator.EvaluateWinner(
                    "5D 8C 9S JS AC".Split(' '),
                    "2C 5C 7D 8S QH".Split(' ')));
        }

        [Fact]
        public void ThirdSample()
        {
            var cardEvaluator = new CardEvaluator();
            var player1Score = cardEvaluator.Evaluate("2D 9C AS AH AC".Split(' '));
            var player2Score = cardEvaluator.Evaluate("3D 6D 7D TD QD".Split(' '));
            Assert.True(player2Score > player1Score);
        }

        [Fact]
        public void FourthSample()
        {
            var cardEvaluator = new CardEvaluator();
            Assert.Equal(1,
                cardEvaluator.EvaluateWinner(
                    "4D 6S 9H QH QC".Split(' '),
                    "3D 6D 7H QD QS".Split(' ')));
        }

        [Fact]
        public void FifthSample()
        {
            var cardEvaluator = new CardEvaluator();
            var player1Score = cardEvaluator.Evaluate("2H 2D 4C 4D 4S".Split(' '));
            var player2Score = cardEvaluator.Evaluate("3C 3D 3S 9S 9D".Split(' '));
            Assert.True(player1Score > player2Score);
        }
    }
}
