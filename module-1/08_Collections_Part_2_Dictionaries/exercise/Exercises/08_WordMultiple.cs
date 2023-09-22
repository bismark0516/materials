using System.Collections.Generic;
using System.Linq.Expressions;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         * Given an array of strings, return a Dictionary<string, Boolean> where each different string is a key and value
         * is true only if that string appears 2 or more times in the array.
         *
         * WordMultiple(["a", "b", "a", "c", "b"]) → {"b": true, "c": false, "a": true}
         * WordMultiple(["c", "b", "a"]) → {"b": false, "c": false, "a": false}
         * WordMultiple(["c", "c", "c", "c"]) → {"c": true}
         *
         */
        public Dictionary<string, bool> WordMultiple(string[] words)
        {
            Dictionary<string, bool> result = new Dictionary<string, bool>();
            Dictionary<string, int> wordC = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (wordC.ContainsKey(word))
                {
                    wordC[word]++;
                }
                else
                {
                    wordC[word] = 1;
                }
            }
            foreach (KeyValuePair<string, int> pair in wordC)
            {
                result[pair.Key] = pair.Value >= 2;
            }
            return result;

        }
    }
}
