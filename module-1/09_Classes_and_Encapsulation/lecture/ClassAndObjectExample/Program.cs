using System;

namespace ClassAndObjectExample
{
   public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Pet bella = new Pet();
            bella.PetName = "Bella Ann von Bexley";
            bella.Owner = "John";

            Console.WriteLine(bella.PetName + " is with " + bella.Owner);

            Console.WriteLine(bella.PetInfo());

            Pet primrose = new Pet();
            primrose.PetName = "Primrose";
            Console.WriteLine(primrose.PetInfo());

            Pet gabriel = new Pet("Gabriel");

            Console.WriteLine(gabriel.PetName);
        } 
    }
}
