using System;
using System.IO;

namespace Lecture.Aids
{
    public static class WritingTextFiles
    {
        /*
        * This method below provides sample code for printing out a message to a text file.
        */
        public static void WritingAFile()
        {

            string filepath = @"c:\niceplace\times.txt";

            using (StreamWriter sw = new StreamWriter(filepath, true))
            {
                sw.WriteLine(DateTime.UtcNow);
            }

            // After the using statement ends, file has now been written
            // and closed for further writing
        }
    }
}
