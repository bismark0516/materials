﻿using System.Collections.Generic;

namespace Exercises
{
    public partial class Exercises
    {
        /*
        Given a List of Integers, and an int value, return true if the int value appears two or more times in
        the list.
	    FoundIntTwice( [5, 7, 9, 5, 11], 5 ) -> true
	    FoundIntTwice( [6, 8, 10, 11, 13], 8 -> false
	    FoundIntTwice( [9, 9, 44, 2, 88, 9], 9) -> true
        */
        public bool FoundIntTwice(List<int> integerList, int intToFind)
        {
            int count = 0;

            foreach (int item in integerList)
            {
                if (item == intToFind)
                {
                    count++;
                }

                else
                {
                    if (count >= 2) 
                    return true;
                }
            }
            return false;

        }
    }
}
