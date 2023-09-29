using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tests
{
    [TestClass]
    public class NonStartTest
    {
        [TestMethod]
        public void GetPartialString()
        {
            //arrange

            NonStart testObject = new NonStart();

            //act

            string result = testObject.GetPartialString("Hello", "There");

            //assert

            Assert.AreEqual("ellohere", result);
        }

        [TestMethod]
        public void GetPartialString_()
        {
            //arrange

            NonStart testObject = new NonStart();

            //act

            string result = testObject.GetPartialString("java", "code");

            //assert

            Assert.AreEqual("avaode", result);

        }

        [TestMethod]
        public void GetPartialString__()
        {
            //arrange

            NonStart testObject = new NonStart();

            //act

            string result = testObject.GetPartialString("shotl", "java");

            //assert

            Assert.AreEqual("hotlava", result);

        }



    }
}
