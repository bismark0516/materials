using System;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            int catCount = (int)3.9;
            decimal moneyInPocket = 12.65m;
            int myMoney = (int)moneyInPocket;
            int moneyInBank = 13;
            decimal totalMoney = moneyInBank + 20;

            const int dogCount = 1;
            //dogCount = dogCount + 1;


            string petType;

            if (dogCount == 1)
            {
                petType = "dog";
            }
            else
            {
                Console.WriteLine("You don't have one dog.");
                petType = "";
            }

            Console.WriteLine("Your pet type is " + petType);

        }
    }
}
