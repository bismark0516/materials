using System;

namespace LinearConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            const double mmToFeetConvFactor = 3.28084;
            const double ftToMetersConvFactor = 0.3048;
           
            double length = 0;
            char units = 'x';
            double convertedLength = 0;

            Console.WriteLine("Please enter a length: ");
            string lengthValue = Console.ReadLine();

            Console.WriteLine("Is this M or F: ");
            string unitValue = Console.ReadLine();

            if (unitValue == "M" || unitValue == "m")
            {
                length = double.Parse(lengthValue);
                convertedLength = length * mmToFeetConvFactor;
                units = 'F';
            }
            else if (unitValue == "F" || unitValue == "f")
            {
                length = double.Parse(lengthValue);
                convertedLength = length * ftToMetersConvFactor;
                units = 'M';
            }
            else
            {
                Console.WriteLine("Invalid entry. Please re-enter: ");
            }

            Console.WriteLine($"{lengthValue} {unitValue} is {convertedLength} {units}");

        }
    }
}
