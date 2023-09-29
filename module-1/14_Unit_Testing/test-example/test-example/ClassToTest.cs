using System;
using System.Collections.Generic;
using System.Text;

namespace test_example
{
    public class ClassToTest
    {

        public int MethodToTest(int[] nums)
        {
            int average = 0;
            int sum = 0;

            foreach (int item in nums)
            {
                sum = sum + item;
                // sum += item 
            }
            average = (int)(Math.Round((double)sum / nums.Length));

           



            return average;
        }

    }
}
