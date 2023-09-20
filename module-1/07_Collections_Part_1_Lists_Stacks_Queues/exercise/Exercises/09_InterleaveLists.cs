using System;
using System.Collections.Generic;

namespace Exercises
{
    public partial class Exercises
    {
        /*
        Given two lists of Integers, interleave them beginning with the first element in the first list followed
        by the first element of the second. Continue interleaving the elements until all elements have been interwoven.
        Return the new list. If the lists are of unequal lengths, simply attach the remaining elements of the longer
        list to the new list before returning it.
        DIFFICULTY: HARD
        InterleaveLists( [1, 2, 3], [4, 5, 6] )  ->  [1, 4, 2, 5, 3, 6]
        */
        public List<int> InterleaveLists(List<int> listOne, List<int> listTwo)
        {
            List<int> listResult = new List<int>();

            int length1 = listOne.Count;
            int length2 = listTwo.Count;

            int maxLength = length1 + length2;
            int j = 0;
            int k = 0;
            int minLength = 0;
            int biggerList = 0;


            if (length1 < length2)
            {
                minLength = length1;
                biggerList = 2; // list 2 is bigger
            }
            else
            {
                minLength = length2;
                biggerList = 1; // list 1 is bigger
            }

            for (int i = 0; i < maxLength; i++)
            {
                if (i % 2 == 0 && i < minLength * 2)
                {
                    listResult.Add(listOne[j]);
                    j++;
                }
                else if (i % 2 == 1 && i < minLength * 2)
                {
                    listResult.Add(listTwo[k]);
                    k++;
                }

                else if (i >= minLength * 2)
                {
                    if (biggerList == 1)
                    {
                        listResult.Add(listOne[j]);
                        j++;
                    }
                    else
                    {
                        listResult.Add(listTwo[k]);
                        k++;
                    }
;
                }
            }
            return listResult;
        }
    }
}

