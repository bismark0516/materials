﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public abstract class Deck
    {
        private List<Card> Cards { get; set; } = new List<Card>();

        public abstract int  HandSize {get;}
        protected string[] Suits { get; } = { "Spades", "Diamonds", "Hearts", "Clubs" };

        protected void CreateDeck(string[] values)
        {

            foreach(string suit in Suits)
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

        /// <summary>
        /// Remove and return the card at the top of the deck
        /// </summary>
        /// <returns></returns>
        public Card DealACard()
        {
            if (Cards.Count > 0)
            {
                Card temp = Cards[0];
                Cards.RemoveAt(0);
                return temp;
            }
            else
            {
                return null;
            }
        }
    }
}
