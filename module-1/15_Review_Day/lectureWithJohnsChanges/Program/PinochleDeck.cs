using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class PinochleDeck :Deck
    {

        private string[] values = { "A", "9", "10", "J", "Q", "K", "A", "9", "10", "J", "Q", "K" };
        public override int HandSize { get; } = 5;
        public PinochleDeck()
        {
            CreateDeck(values);
        }
    }
}
