using System;
using System.IO;

namespace FindAndReplace
{
    public class Program
    {

        public static void Main(string[] args)
        {

            Console.WriteLine("What is the search word?");
            string searchWord = Console.ReadLine();

            Console.WriteLine(" What is the replacement word?");
            string replacementWord = Console.ReadLine();

            Console.WriteLine(" What is the source file?");
            string sourceFile = Console.ReadLine();


            Console.WriteLine("What is the destination file?");
            string destinationFile = Console.ReadLine();



            try

            {
                using (StreamReader sr = new StreamReader(sourceFile))
                {

                    using (StreamWriter sw = new StreamWriter(destinationFile, false))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();

                            string newLine = line.Replace(searchWord,replacementWord);
                            
                           sw.WriteLine(newLine);
                        }
                    }

                }

            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
