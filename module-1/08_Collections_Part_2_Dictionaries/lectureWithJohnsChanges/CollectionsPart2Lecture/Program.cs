using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CollectionsPart2Lecture
{
    public class CollectionsPart2Lecture
	{
        static void Main(string[] args)
        {

            Console.WriteLine("####################");
            Console.WriteLine("       HASHSET");
            Console.WriteLine("####################");
            Console.WriteLine();

            HashSet<string> names = new HashSet<string>();
            names.Add("John");
            names.Add("John");
            names.Add("Nancy");
            names.Add("Lisa");

            List<string> myList = names.ToList(); ;


            Console.WriteLine("####################");
			Console.WriteLine("       DICTIONARIES");
			Console.WriteLine("####################");
			Console.WriteLine();

            Dictionary<string, int> locationA = new Dictionary<string, int>();
            locationA["a234"] = 7;
            locationA["br123"] = 3;
            locationA["t56"] = 19;

            Dictionary<string, int> locationB = new Dictionary<string, int>();
            locationB["b234"] = 7;
            locationB["xy123"] = 3;
            locationB["t56"] = 19;


            Dictionary<string, int> inventory = new Dictionary<string, int>();

            foreach(string itemKey in locationA.Keys)
            {
                inventory[itemKey] = locationA[itemKey];
            }

            foreach (string itemKey in locationB.Keys)
            {
                if (inventory.ContainsKey(itemKey))
                {
                    inventory[itemKey] = inventory[itemKey] + locationB[itemKey];
                }
                else
                {
                    inventory[itemKey] = locationB[itemKey];
                }
            }
        }
	}
}
