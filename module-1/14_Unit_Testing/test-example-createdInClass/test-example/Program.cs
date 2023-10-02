using System;

namespace test_example
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] inputValue = new int[] { 1, 2, 3 };

            ClassToTest classToTest = new ClassToTest();

            int result = classToTest.MethodToTest(inputValue);

            if (result == 2)
            {
                Console.WriteLine("Sucess!");
            }
            else
            {
                Console.WriteLine("Abject failure.");
            }
        }
    }
}
