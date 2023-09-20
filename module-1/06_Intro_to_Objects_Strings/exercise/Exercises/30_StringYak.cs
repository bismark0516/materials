﻿namespace Exercises
{
    public partial class StringExercises
    {
        /*
        Suppose the string "yak" is unlucky. Given a string, return a version where all the "yak" are removed.
        The "yak" strings will not overlap.
        StringYak("yakpak") → "pak"
        StringYak("pakyak") → "pak"
        StringYak("yak123ya") → "123ya"
        */
        public string StringYak(string str)
        {
            string result = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (i + 2 < str.Length && str.Substring(i, 3) == "yak") 
                {
                    i += 2;
                }
                else
                {
                    result = result + str[i];
                }
            }


            return result;
        }
    }
}
