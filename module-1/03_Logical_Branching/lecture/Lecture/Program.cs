using System;
using System.Threading;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            int catCount = (int)3.9;
            decimal moneyInPocket = 12.65M;
            int myMoney = (int)moneyInPocket;
            int moneyInBank = 13;
            decimal totalMoney = moneyInBank + 20;
            const int dogCount = 1;




            string petType;

            if (dogCount == 1)
            {
                 petType = "dog";
            }
            else
            { 
                Console.WriteLine("You Don't have one dog.");
                petType = "";
            }

            Console.WriteLine( "Your pet type is " + petType);
        }

    }
}
