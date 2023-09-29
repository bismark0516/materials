using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    class UserInterface
    {
        private Deck deck = new Deck();

        public void Start()
        {
            bool done = false;

            while (!done)
            {
                DisplayMenu();

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        DisplayTheDeck();
                        break;
                    case "2":
                        ShuffleTheDeck();
                        break;
                    case "3":
                        DealACard();
                        break;
                    case "E":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice");
                        Console.WriteLine();
                        break;
                }
            }
        }

        private void DealACard()
        {
            Console.WriteLine("Reached DealACard");
        }

        private void ShuffleTheDeck()
        {
            deck.Shuffle();
        }

        private void DisplayTheDeck()
        {
            string display = deck.DisplayDeck();
            Console.WriteLine(display);
            Console.WriteLine();
        }

        private void DisplayMenu()
        {
            Console.WriteLine("Please enter a choice: ");
            Console.WriteLine("1: Display the deck");
            Console.WriteLine("2: Shuffle the deck");
            Console.WriteLine("3: Deal a card");
            Console.WriteLine("E: End the program");
        }
    }
}
