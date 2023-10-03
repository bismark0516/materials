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
            if(userName == "")
            {
                throw new ArgumentOutOfRangeException("Username cannot be the empty string");
            }

            if (String.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("Username is not valid");
            }

            int zero = 0;
            bool isInputValid = false;
            while (!isInputValid )
            {
                Console.WriteLine($"{userName} Enter 0 (zero) to divide by zero");

                try
                {
                    // could generate a FormatException
                    string userInput = Console.ReadLine();
                    zero = int.Parse(userInput);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine("Invalid input. Please enter digits. ");
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
                Console.WriteLine("An Exception occured: " + ex.Message + " " + ex.StackTrace);
            }


            try
            {
                // could generate an IndexOutOfRangeException
                int[] anArray = new int[10];
                anArray[result] = 34;
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("An Exception occured: " + ex.Message);
            }

            // we will get here only if there are no exceptions
            Console.WriteLine("Thanks for playing our little game.");
        }
    }
}
