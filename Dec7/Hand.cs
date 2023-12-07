﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dec7 {
    internal class Hand : IComparable<Hand>{
        private List<char> cards = new List<char>(5);
        public int Bet { get; }

        public Hand(string cards, int bet) {
            this.Bet = bet;
            this.cards = cards.ToList();
        }

        public HandType Type() {
            var distinctCards = cards.Distinct();

            var noOfPairs = 0;
            var noOfThreeOfAKind = 0;
            
            foreach (var distinctCard in distinctCards) {
                var count = cards.Where(card => card ==  distinctCard).Count();
                if (count == 2) {
                    noOfPairs++;
                }
                if (count == 3) {
                    noOfThreeOfAKind++;
                }
                if (count == 4) {
                    return HandType.FourOfAKind;
                }
                if (count == 5) {
                    return HandType.FiveOfAKind;
                }
            }
            if (noOfPairs == 2) {
                return HandType.TwoPair;
            }
            if (noOfPairs == 1 && noOfThreeOfAKind == 0) {
                return HandType.OnePair;
            }
            if (noOfPairs == 0 && noOfThreeOfAKind == 1) {
                return HandType.ThreeOfAKind;
            }
            if (noOfPairs == 1 && noOfThreeOfAKind == 1) {
                return HandType.FullHouse;
            }

            return HandType.HighCard;
        }

        public int HandStrength () {
            int sum = 0;
            var multiplier = ((int)Math.Pow(15, 5.0));
            foreach (var card in cards) {
                sum += CardStrenght(card) * multiplier;
                multiplier /= 15;
            }
            return sum;
        }

        private int CardStrenght(char card) {
            if (int.TryParse(card.ToString(), out int strength)) {
                return strength;
            }
            switch (card) {
                case 'T': return 10;
                case 'J': return 11;
                case 'Q': return 12;
                case 'K': return 13;
                case 'A': return 14;
            }
            throw new ArgumentException();
        }

        public int CompareTo(Hand? other) {
            if (other == null) return 1;
            if (this.Type() > other.Type()) return 1;
            if (this.Type() < other.Type()) return -1;

            return this.HandStrength() - other.HandStrength();
        }

        public string Cards() {
            return new string(cards.ToArray());
        }
    }
}