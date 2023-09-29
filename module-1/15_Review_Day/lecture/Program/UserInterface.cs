using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    class UserInterface
    {
        private Deck deck;

        private int playerCount = 2;

        private List<Hand> hands = new List<Hand>();

        public void Start()
        {
            bool done = false;

            while (!done)
            {
                DisplayMenu();

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    //switch cases that call methods make things easier allowing the method to do the work. Good example of encapsulation 
                    case "1":
                        ChooseAGame();
                        break;
                    case "2":
                        DisplayTheDeck();
                        break;
                    case "3":
                        ShuffleTheDeck();
                        break;
                    case "4":
                        DealCards();
                        break;
                    case "E":
                    case "e":
                        // if there are two case without a break those cases will cause an execution of the following line
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice");
                        Console.WriteLine();
                        break;
                }
            }
        }

        public void ChooseAGame()
        {
            bool done = false;

            while (!done)
            {
                DisplayGameChoiceMenu();

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    //switch cases that call methods make things easier allowing the method to do the work. Good example of encapsulation 
                    case "1":
                        deck = new PokerDeck();
                        break;
                    case "2":
                        deck = new EucherDeck();
                        break;
                    case "3":
                        deck = new PinochleDeck();
                        break;

                    case "R":
                    case "r":
                        // if there are two case without a break those cases will cause an execution of the following line
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice");
                        Console.WriteLine();
                        break;
                }
            }
        }

        private void DisplayGameChoiceMenu()
        {
            Console.WriteLine("Please enter a choice: ");
            Console.WriteLine("1: Poker: ");
            Console.WriteLine("2: Eucher: ");
            Console.WriteLine("3: Pinochle ");
            Console.WriteLine("R: Return to the main menu");
        }

        private void DealCards()
        {
            // create hands

            while (hands.Count < playerCount)
            {
                hands.Add(new Hand());
            }

            // loop through hands dealing cards 
            foreach (Hand hand in hands)
            {
                if (hand.CardCount < deck.HandSize)
                {
                    hand.Add(deck.DealACard());
                }
            }
            
            
        }

        private void ShuffleTheDeck()
        {
            if (deck != null)
            {

                deck.Shuffle();
            }
            else
            {
                Console.WriteLine("Please select a game ");
                Console.WriteLine();
            }
        }

        private void DisplayTheDeck()
        {
            if (deck != null)
            {
                string display = deck.DisplayDeck();
                Console.WriteLine(display);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Please select a game ");
                Console.WriteLine();
            }

        }

        private void DisplayMenu()
        {
            Console.WriteLine("Please enter a choice: ");
            Console.WriteLine("1: Choose a game: ");
            Console.WriteLine("2: Display the deck");
            Console.WriteLine("3: Shuffle the deck");
            Console.WriteLine("4: Deal cards");
            Console.WriteLine("E: End the program");
        }
    }
}
