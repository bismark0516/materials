using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlingLecture
{
    public class UserInterface
    {
        public void Run()
        {
            Console.WriteLine("Enter 0 (zero) to divide by zero");

            // could generate a FormatException
            string userInput = Console.ReadLine();
            int zero = int.Parse(userInput);

            // could generate a DivideByZeroException
            int result = 27 / zero;

            // could generate an IndexOutOfRangeException
            int[] anArray = new int[10];
            anArray[result] = 34;

            // we will get here only if there are no exceptions
            Console.WriteLine("Thanks for playing our little game.");
        }
    }
}
