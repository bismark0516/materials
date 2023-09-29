using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class PokerDeck :Deck
    {

        private string[] values = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        public override int HandSize { get; } = 5;
        public PokerDeck()
        {
            CreateDeck(values);
        }
    }
}
