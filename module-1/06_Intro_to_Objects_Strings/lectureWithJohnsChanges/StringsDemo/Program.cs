using System;

namespace StringsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 7;
            Console.WriteLine(result);

            Change(result);
            Console.WriteLine(result);


            int[] values = { 3, 1, 4 };
            Console.WriteLine(values[0]);
            Change2(values);
            Console.WriteLine(values[0]);




            string name = "Ada Lovelace";
            Console.WriteLine(name);

            // Strings are actually arrays of characters (char).
            // Those characters can be accessed using [] notation.

            // 1. Write code that prints out the first and last characters
            //      of name.
            // Output: A
            // Output: e

            Console.WriteLine("First and Last Character. ");
            Console.WriteLine(name[0]);
            Console.WriteLine(name[name.Length - 1]);

            // 2. How do we write code that prints out the first three characters
            // Output: Ada

            Console.WriteLine("First 3 characters: ");
            Console.WriteLine(name.Substring(0, 3));

            // 3. Now print out the first three and the last three characters
            // Output: Adaace

            Console.WriteLine();
            Console.WriteLine("Last 3 characters: ");
            Console.WriteLine(name.Substring(name.Length - 3));

            // 4. What about the last word?
            // Output: Lovelace

            Console.WriteLine();
            Console.WriteLine("Last Word: ");
            string[] last = name.Split(" ");
            Console.WriteLine(last[last.Length - 1]);

            // 5. Does the string contain inside of it "Love"?
            // Output: true

            Console.WriteLine();
            Console.WriteLine("Contains \"Love\"");
            Console.WriteLine(name.Contains("Love"));

            // 6. Where does the string "lace" show up in name?
            // Output: 8

            Console.WriteLine();
            Console.WriteLine("Index of \"lace\": ");
            Console.WriteLine(name.IndexOf("lace"));

            // 7. How many 'a's OR 'A's are in name?
            // Output: 3

            Console.WriteLine();
            Console.WriteLine("Number of \"a's\": ");
            string lower = name.ToLower();
            string[] aCount = lower.Split("a");
            Console.WriteLine(aCount.Length - 1);

            // 8. Replace "Ada" with "Ada, Countess of Lovelace"

            Console.WriteLine();
            Console.WriteLine(name);
            Console.WriteLine(name.Replace("Ada", "Ada, Countess of Lovelace"));

            // 9. Set name equal to null.

            name = null;

            // 10. If name is equal to null or "", print out "All Done".
            if (String.IsNullOrEmpty(name))
            {
                Console.WriteLine("All Done");
            }
        }

        static void Change(int input)
        {
            input = input + 1;
            return;
        }

        static void Change2(int[] input)
        {
            input[0] = 113;
            return;
        }
    }
}
