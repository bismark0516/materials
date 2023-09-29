using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class PinochleDeck :Deck
    {

        private string[] values = { "A", "9", "10", "J", "Q", "K", "A", "9", "10", "J", "Q", "K" };

        public PinochleDeck()
        {
            CreateDeck(values);
        }
    }
}
