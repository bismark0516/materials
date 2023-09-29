using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tests
{
    [TestClass]
    public class StringBitsTest
    {

        [TestMethod]
        public void GetBits()
        {
            //arrange

            StringBits testObject = new StringBits();

            //act

            string result = testObject.GetBits("Hello");

            //assert

            Assert.AreEqual("Hlo", result);
        }
        [TestMethod]
        public void GetBits_()
        {
            //arrange

            StringBits testObject = new StringBits();

            //act

            string result = testObject.GetBits("Hi");

            //assert

            Assert.AreEqual("H", result);
        }
        [TestMethod]
        public void GetBits__()
        {
            //arrange

            StringBits testObject = new StringBits();

            //act

            string result = testObject.GetBits("Heeololeo");

            //assert

            Assert.AreEqual("Hello", result);
        }









    }
}
