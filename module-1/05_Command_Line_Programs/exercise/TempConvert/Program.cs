using System;

namespace TempConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            double temp = 0;
            char units = 'x';
            double convertedTemp = 0;

            Console.WriteLine("Please enter Temperature Value: ");
            string tempValue = Console.ReadLine();

            Console.WriteLine("Is this C or F: ");
            string tempUnit = Console.ReadLine();

            if (tempUnit == "C" || tempUnit == "c")
            {
                temp = double.Parse(tempValue);
                convertedTemp = (temp * 9 / 5) + 32;
                units = 'F';
            }
            else if (tempUnit == "F" || tempUnit == "f")
            {
                temp = double.Parse(tempValue);
                convertedTemp = (temp - 32) * 5 / 9;
                units = 'C';
            }
            else
            {
                Console.WriteLine("Invalid entry. Please re-enter: ");
            }

            Console.WriteLine(convertedTemp);

        }

    }

}
