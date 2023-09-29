using System;

namespace test_example
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] inputValues = new int[] { 1, 2, 3 };

            ClassToTest classToTest = new ClassToTest();

            int result = classToTest.MethodToTest(inputValues);

            if (result == 2)
            {
                Console.WriteLine( "Success!");
            }
            else
            {
                Console.WriteLine( "Abject Failure.");
            }
        }
    }

}
