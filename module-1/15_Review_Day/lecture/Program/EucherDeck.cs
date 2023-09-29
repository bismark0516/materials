using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class EucherDeck:Deck
    {
        private string[] values { get; } = { "A", "9", "10", "J", "Q", "K" };

        public override int HandSize { get; } = 5;
        public EucherDeck()
        {
            CreateDeck(values);
        }


    }
}
