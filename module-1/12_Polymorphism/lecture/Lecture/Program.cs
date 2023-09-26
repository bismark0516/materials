using Lecture.Farming;
using System;
using System.Net.Http.Headers;

namespace Lecture
{
    public class Program
    {
        public static void Main()
        {
            //
            // OLD MACDONALD
            //

            //FarmAnimal[] animals = new FarmAnimal[] { new Cow(), new Chicken(), new Dog() };
            IMakeSound[] farmItems = new IMakeSound[] { new Tractor(), new Cow(), new Dog() };

            foreach (IMakeSound item in farmItems)
            {
                Console.WriteLine("Old MacDonald had a farm, ee ay ee ay oh!");
                Console.WriteLine("And on his farm he had a " + item.Name + ", ee ay ee ay oh!");
                Console.WriteLine("With a " + item.Sound + " " + item.Sound + " here");
                Console.WriteLine("And a " + item.Sound + " " + item.Sound + " there");
                Console.WriteLine("Here a " + item.Sound + " there a " + item.Sound + " everywhere a " + item.Sound + " " + item.Sound);
                Console.WriteLine();
            }

            Console.WriteLine("Old MacDonald had a farm, ee ay ee ay oh!");
        }
    }
}
