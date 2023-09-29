using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tests
{
    [TestClass]
    public class FrontTimesTest
    {

        [TestMethod]
        public void GenerateString()
        {
            //arrange

            FrontTimes TestObject = new FrontTimes();

            //act
            string result = TestObject.GenerateString("cho", 3);


            //assert
            Assert.AreEqual("chochocho", result);
        }

        [TestMethod]
        public void GenerateString_()
        {
            //arrange

            FrontTimes TestObject = new FrontTimes();

            //act
            string result = TestObject.GenerateString("", 3);


            //assert
            Assert.AreEqual("", result);
        }

    }
}
