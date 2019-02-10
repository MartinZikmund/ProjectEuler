using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Problem54
{
    public class CardEvaluator
    {
        private const int NotApplicable = -1;
        private const int RoyalFlushValueBase = 2000;
        private const int StraightFlushValueBase = 1900;
        private const int FourOfAKindValueBase = 1800;
        private const int FullHouseValueBase = 1200;
        private const int FlushValueBase = 1000;
        private const int StraightValueBase = 800;
        private const int ThreeOfAKindValueBase = 600;
        private const int TwoPairsValueBase = 300;
        private const int OnePairValueBase = 200;
        private const int HighCardValueBase = 100;

        delegate int HandEvaluator(string[] hand);

        private HandEvaluator[] _evaluators;

        public CardEvaluator()
        {
            _evaluators = new HandEvaluator[]
            {
                GetRoyalFlushValue,
                GetStraightFlushValue,
                GetFourOfAKindValue,
                GetFullHouseValue,
                GetFlushValue,
                GetStraightValue,
                GetThreeOfAKindValue,
                GetTwoPairsValue,
                GetOnePairValue
            };
        }

        public int Evaluate(string[] hand)
        {
            if (hand.Length != 5) throw new ArgumentOutOfRangeException(nameof(hand));
            var currentResult = -1;
            int currentEvaluatorId = 0;
            do
            {
                currentResult = _evaluators[currentEvaluatorId](hand);
                currentEvaluatorId++;
            } while (currentResult == -1 && currentEvaluatorId < _evaluators.Length);

            return currentResult;
        }

        public int[] GetValuesInDescendingOrder(string[] hand)
        {
            return hand.Select(GetCardValue).OrderByDescending(v => v).ToArray();
        }

        private int GetOnePairValue(string[] hand)
        {
            var pair = hand.Select(GetCardValue)
                .GroupBy(v => v).SingleOrDefault(g => g.Count() == 2);
            if (pair == null) return NotApplicable;
            return OnePairValueBase + pair.First();
        }

        private int GetTwoPairsValue(string[] hand)
        {
            var pairs = hand.Select(GetCardValue)
                .GroupBy(v => v)
                .Where(g => g.Count() == 2)
                .OrderBy(g => g.First()).ToArray();
            if (pairs.Count() != 2) return NotApplicable;
            var firstPairValue = pairs.First().First();
            var secondPairValue = pairs.Last().First();
            return TwoPairsValueBase + secondPairValue * 15 + firstPairValue;
        }

        private int GetThreeOfAKindValue(string[] hand)
        {
            var group = hand.Select(GetCardValue).GroupBy(v => v).FirstOrDefault(g => g.Count() == 3);
            if (group == null) return NotApplicable;
            return ThreeOfAKindValueBase + group.First();
        }

        private int GetStraightValue(string[] hand)
        {
            var values = hand.Select(GetCardValue).OrderBy(v => v).ToArray();
            if (values.GroupBy(v => v).Any(g => g.Count() > 1)) return NotApplicable;
            if (values.Last() != values.First() + 4) return NotApplicable;
            return StraightValueBase + values.Max();
        }

        private int GetFlushValue(string[] hand)
        {
            if (hand.GroupBy(GetCardSuit).Count() > 1) return NotApplicable;
            return FlushValueBase;
        }

        private int GetFullHouseValue(string[] hand)
        {
            var groups = hand.Select(GetCardValue).GroupBy(v => v).OrderBy(g => g.Count()).ToArray();
            if (groups.Length != 2 || groups.First().Count() != 2 || groups.Last().Count() != 3) return NotApplicable;
            var tripletValue = groups.Last().First();
            var pairValue = groups.First().First();
            return FullHouseValueBase + tripletValue * 15 + pairValue;
        }

        private int GetFourOfAKindValue(string[] hand)
        {
            var group = hand.Select(GetCardValue).GroupBy(v => v).FirstOrDefault(g => g.Count() == 4);
            if (group == null) return NotApplicable;
            return FourOfAKindValueBase + group.First();
        }

        private int GetStraightFlushValue(string[] hand)
        {
            if (hand.GroupBy(GetCardSuit).Count() > 1) return NotApplicable;
            var ordered = hand.OrderBy(GetCardValue).Select(GetCardValue).ToArray();
            if (ordered.Last() != ordered.First() + 4) return NotApplicable;
            return StraightFlushValueBase + ordered.First();
        }

        private int GetRoyalFlushValue(string[] hand)
        {
            if (hand.GroupBy(GetCardSuit).Count() > 1) return NotApplicable;
            if (hand.Any(c => GetCardValue(c) < 11)) return NotApplicable;
            return RoyalFlushValueBase;
        }

        private char GetCardSuit(string card) => card[1];

        private int GetCardValue(string card)
        {
            switch (card[0])
            {
                case char c when char.IsDigit(c):
                    {
                        return c - '0';
                    }
                case 'T': return 10;
                case 'J': return 11;
                case 'Q': return 12;
                case 'K': return 13;
                case 'A': return 14;
                default: throw new ArgumentOutOfRangeException(nameof(card));
            }
        }


        public int HighCardWinner(string[] hand1, string[] hand2)
        {
            var orderedFirst = GetValuesInDescendingOrder(hand1);
            var orderedSecond = GetValuesInDescendingOrder(hand2);
            for (int i = 0; i < orderedFirst.Length; i++)
            {
                if (orderedFirst[i] > orderedSecond[i])
                {
                    return 1;
                }
                else if (orderedSecond[i] > orderedFirst[i])
                {
                    return 2;
                }
            }
            throw new InvalidDataException();
        }

        public int EvaluateWinner(string[] hand1, string[] hand2)
        {

            var firstPlayerScore = Evaluate(hand1);
            var secondPlayerScore = Evaluate(hand2);
            if (firstPlayerScore > secondPlayerScore)
            {
                return 1;
            }
            else if (firstPlayerScore < secondPlayerScore)
            {
                return 2;
            }
            else
            {
                return HighCardWinner(hand1, hand2);
            }
        }
    }
}
