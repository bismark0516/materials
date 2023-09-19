using System;
using System.Collections.Generic;

namespace CollectionsPart1Lecture
{
    public class CollectionsPart1Lecture
	{
        static void Main(string[] args)
        {
			Console.WriteLine("####################");
			Console.WriteLine("       LISTS");
			Console.WriteLine("####################");

			List<string> names = new List<string>();
			names.Add("Brian");
			names.Add("Steve");
			names.Add("Rachelle");

			PrintList(names);

			Console.WriteLine("####################");
			Console.WriteLine("Lists are ordered");
			Console.WriteLine("####################");
			names.Insert(0, "John");

            PrintList(names);


            Console.WriteLine("####################");
			Console.WriteLine("Lists allow duplicates");
			Console.WriteLine("####################");

			names.Add("John");
			PrintList(names);


			Console.WriteLine("####################");
			Console.WriteLine("Lists allow elements to be inserted in the middle");
			Console.WriteLine("####################");
			
			names.Insert(3, "Matt");
			PrintList(names);


			Console.WriteLine("####################");
			Console.WriteLine("Lists allow elements to be removed by index");
			Console.WriteLine("####################");

			int lastIndex = names.Count - 1;
			names.RemoveAt(lastIndex);
			PrintList(names);

			Console.WriteLine("####################");
			Console.WriteLine("Find out if something is already in the List");
			Console.WriteLine("####################");
			bool result = names.Contains("Rachelle");
            Console.WriteLine("Found Rachell? " + result);


            Console.WriteLine("####################");
			Console.WriteLine("Find index of item in List");
			Console.WriteLine("####################");
			Console.WriteLine("Location of Rachelle in list: " + names.IndexOf("Rachelle"));

			Console.WriteLine("####################");
			Console.WriteLine("Lists can be turned into an array");
			Console.WriteLine("####################");
			string[] arrayNames = names.ToArray();
			PrintList(arrayNames);

			Console.WriteLine("####################");
			Console.WriteLine("Lists can be sorted");
			Console.WriteLine("####################");
			names.Sort();
			PrintList(names);

			Console.WriteLine("####################");
			Console.WriteLine("Lists can be reversed too");
			Console.WriteLine("####################");
			names.Reverse();
			PrintList(names);

			Console.WriteLine("####################");
			Console.WriteLine("       FOREACH");
			Console.WriteLine("####################");
			Console.WriteLine();

            Console.WriteLine("####################");
            Console.WriteLine("       STACK");
            Console.WriteLine("####################");

            Stack<int> numbers = new Stack<int>();
			numbers.Push(45);
			numbers.Push(12);
			numbers.Push(3);
            Console.WriteLine(numbers.Peek());
            Console.WriteLine(numbers.Pop());
            Console.WriteLine("Count: "+ numbers.Count);
            Console.WriteLine(numbers.Pop());
            Console.WriteLine("Count: " + numbers.Count);


            Console.WriteLine("####################");
            Console.WriteLine("       QUEUE");
            Console.WriteLine("####################");

			Queue<string> pets = new Queue<string>();
			pets.Enqueue("Bella");
			pets.Enqueue("Primrose");
			pets.Enqueue("Gabe");

            Console.WriteLine("Count: " + pets.Count);
            Console.WriteLine(pets.Peek());

            Console.WriteLine(pets.Dequeue());
            Console.WriteLine("Count: " + pets.Count);

            Console.WriteLine(pets.Dequeue());
            Console.WriteLine("Count: " + pets.Count);


        }

        static void PrintList(List<string> thisList)
		{
            Console.WriteLine();
            foreach (string name in thisList)
			{
                Console.WriteLine(name);
            }
		}

        static void PrintList(string[] thisList)
        {
            Console.WriteLine();
            foreach (string name in thisList)
            {
                Console.WriteLine(name);
            }
        }
    }
}
