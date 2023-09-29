using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tests
{
    [TestClass]
    public class Less20Test
    {
        [TestMethod]

        public void IsLessThanMulitpleOf20()
        {
            //arrange

            Less20 testObject = new Less20();

            //act
            bool result = testObject.IsLessThanMultipleOf20(18);


            //assert
            Assert.AreEqual(true, result);
        }


        [TestMethod]

        public void IsLessThanMulitpleOf20_()
        {
            //arrange

            Less20 testObject = new Less20();

            //act
            bool result = testObject.IsLessThanMultipleOf20(19);


            //assert
            Assert.AreEqual(true, result);

        }
        [TestMethod]

        public void IsLessThanMulitpleOf20__()
        {
            //arrange

            Less20 testObject = new Less20();

            //act
            bool result = testObject.IsLessThanMultipleOf20(20);


            //assert
            Assert.AreEqual(false, result);

        }

    }
}
