using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using test_example;

namespace Test_Example_Test
{
    [TestClass]
    public class ClassToTest_test
    {
        [TestMethod]
        public void MethodToTest_With_123()
        {
            //arrange sets up the values that need to be tested
            int[] inputValue = new int[] { 1, 2, 3 };
            ClassToTest classToTest = new ClassToTest();

            //act
            int result = classToTest.MethodToTest(inputValue);


            //assert
            Assert.AreEqual(2, result);

        }


    }
}
