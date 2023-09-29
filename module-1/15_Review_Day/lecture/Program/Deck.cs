using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    class Deck
    {
        private List<Card> Cards { get; set; } = new List<Card>();


        private string[] suits = { "Spades", "Diamonds", "Hearts", "Clubs" };
        private string[] values = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
       
        public Deck ()
        {
            CreateDeck();
        }

        private void CreateDeck()
        {

            foreach(string suit in suits)
            {
                foreach (string value in values)
                {
                    Card card = new Card(suit, value, false);
                    Cards.Add(card);
                }
            }

        }


        public string DisplayDeck()
        {
            string result = "";

            foreach (Card item in Cards)
            {
                result += item.ToString() + "\n";
            }

            return result;
        }

        public void Shuffle()
        {
            Random random = new Random();

          for (int i = 0; i < Cards.Count; i++)
            {
                int j = random.Next(Cards.Count);
                Card temp = Cards[i];
                Cards[i] = Cards[j];
                Cards[j] = temp;
            }
        }

        public Card DealACard()
        {
            throw new NotImplementedException();
        }
    }
}
