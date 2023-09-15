﻿using System;

namespace MakeChange
{
    class Program
    {
        /*
        Write a command line program which prompts the user for the total bill, and the amount tendered. 
        It should then display the change required.

        C:\Users> MakeChange

        Please enter the amount of the bill: 23.65
        Please enter the amount tendered: 100.00
        The change required is 76.35
        */
        static void Main(string[] args)
        {
            Console.Write("Please ednter the total bill: ");
            string billAmount = Console.ReadLine();
            decimal bill = decimal.Parse(billAmount);

            Console.Write("Please enter than amount tendered: ");
            string tenderedAmount = Console.ReadLine();
            decimal tendered = decimal.Parse(tenderedAmount);

            decimal change = tendered - bill;
            Console.WriteLine("Your change is: " + change);
        }
    }
}
