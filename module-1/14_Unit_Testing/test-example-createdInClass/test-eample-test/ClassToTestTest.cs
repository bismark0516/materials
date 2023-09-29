using Microsoft.VisualStudio.TestTools.UnitTesting;
using test_example;

namespace test_eample_test
{
    [TestClass]
    public class ClassToTestTest
    {
        [TestMethod]
        public void MethodToTest_with_123()
        {
            //Arrange
            int[] inputValue = new int[] { 1, 2, 3 };
            ClassToTest classToTest = new ClassToTest();

            //Act
           int result =  classToTest.MethodToTest(inputValue);

            //Assert
            Assert.AreEqual(2, result);
        }
    }
}
