using System;

namespace DecimalToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter decimals separated by spaces:" );
            string userInput = Console.ReadLine();
            string[] decimalS = userInput.Split(" ");

            for (int i = 0; i < decimalS.Length; i++)
            {
                int dValue = int.Parse(decimalS[i]);
                string bValue = " ";

                // here is where you need to do a nested for loop for the conversion
                for (int j = 0; dValue > 0; j++)
                {
                    int remainder = dValue % 2;
                    bValue = remainder + bValue;
                    dValue = dValue / 2;
                    // here is where you need to assign the converted value to a variable outside the second loop and save as an array because it is multiple values
                }
                Console.WriteLine($" {decimalS[i]} in binary is: {bValue}");
                // you will need a user input array and binary array (int originalDecimalValue = decimalValue); using this formula console.writeLine ( "user.input" + " " + "in binary is " + "binaryvalue")

            }
        }
    }
}
