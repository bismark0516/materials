using System;

namespace DiscountCalculator
{
    class Program
    {
        /// <summary>
        /// The main method is the start and end of our program.
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
            Console.WriteLine("Welcome to the Discount Calculator");

            // Prompt the user for a discount amount
            // The answer needs to be saved as a double
            Console.Write("Enter the discount amount (w/out percentage) (for example 0.05): ");
            string discount = Console.ReadLine();
            double percent = double.Parse(discount);

            // Prompt the user for a series of prices
            Console.Write("Please provide a series of prices (space separated): ");

            string prices = Console.ReadLine();
            string[] amounts = prices.Split(" ");

            for (int i = 0; i < amounts.Length; i++)
            {

                double temp = double.Parse(amounts[i]);

                double disc = temp - temp * percent;

                Console.WriteLine("Amount: " + disc + " is discounted by " + (percent * 100) + "%");
            }

        }
    }
}
