using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class Hand
    {
        private List<Card> cards = new List<Card>();
        public int CardCount
        {
            get
            {
                return cards.Count;
            }
        }
        

            

        public override string ToString()
        {
            if (cards.Count == 0)
            {
                return "empty";
            }
            else
            {
                string result = "";
                foreach (Card card in cards)
                {
                    result += card.ToString() + "\n";
                }
                return result;
            }
           
        }
    }
}
