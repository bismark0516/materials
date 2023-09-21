﻿using System.Collections.Generic;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         * Given an array of non-empty strings, return a Dictionary<string, string> where, for every string in the array,
         * there is an entry whose key is the first character of the string.
         * 
         * The value of the entry is the last character of the string. If multiple strings start with the same letter, then the value for 
         * that key should be the later string's last character.
         *
         * BeginningAndEnding(["code", "bug"]) → {"b": "g", "c": "e"}
         * BeginningAndEnding(["code", "bug", "cat"]) → {"b": "g", "c": "t"}
         * BeginningAndEnding(["muddy", "good", "moat", "good", "night"]) → {"g": "d", "m": "t", "n": "t"}
         */
        public Dictionary<string, string> BeginningAndEnding(string[] words)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            foreach (string word in words)
            {
                if (!string.IsNullOrEmpty (word) && word.Length > 0)
                {
                    string first = word.Substring(0, 1);
                    string last = word.Substring(word.Length - 1);

                    result[first] = last;
                }
            }

                return result;
        }
    }
}
