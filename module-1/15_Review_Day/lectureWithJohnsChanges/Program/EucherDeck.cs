using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class EucherDeck :Deck
    {

        private string[] values = { "A", "9", "10", "J", "Q", "K" };

        public EucherDeck()
        {
            CreateDeck(values);
        }
    }
}
