using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Provide a number to generate the Fibonacci sequence");
            string userInput = Console.ReadLine();

            int n = 0;
            
                n = int.Parse(userInput);

                Console.WriteLine("Fibonacci Sequence: ");

                int a = 0;
                int b = 1;
                int c;
               
                if (n >= 1)
                {
                    Console.WriteLine(a);
                }
                if (n >= 2)
                {
                    Console.WriteLine(b);
                }
                for (int i =3; a + b <= n; i++)
                {
                    c = a + b;
                    Console.WriteLine(c);
                    a = b;
                    b = c;
                }
        }
    }
}
