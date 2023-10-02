using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlingLecture
{
    public class UserInterface
    {
        public void Run(string userName = "")
        {
            if (userName == "")   
            {
                throw new ArgumentOutOfRangeException("Username cannot be then empty string");
            }


            if (String.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("UserName is not valid");
            }


            bool isInputValid = false;
            int zero = 0;
            while (!isInputValid)
            {

                Console.WriteLine($"{userName}, Enter 0 (zero) to divide by zero");

                try
                {
                    // could generate a FormatException
                    string userInput = Console.ReadLine();
                    zero = int.Parse(userInput);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Invalid input. Please enter digits.");
                    continue;
                }

                isInputValid = true;
            }



            int result = 10;
            try
            {
                // could generate a DivideByZeroException
                 result = 27 / zero;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("An exception occured: " + ex.Message + " " + ex.StackTrace);
            }

            try
            {
                // could generate an IndexOutOfRangeException
                int[] anArray = new int[10];
                anArray[result] = 34;
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("An exception occured: " + ex.Message);
            }

            throw new JohnHasDoneSomethingBadException("Something really, relly bad");

            // we will get here only if there are no exceptions
            Console.WriteLine("Thanks for playing our little game.");
        }
    }
}
