using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tests
{
    [TestClass]
    public class DateFashionTest
    {

        [TestMethod]



        public void GetATable()
        {


            //arrange
            DateFashion testObject = new DateFashion();

            //act
            int result = testObject.GetATable(2, 2);

            //assert

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetATable_()
        {


            //arrange
            DateFashion testObject = new DateFashion();

            //act
            int result = testObject.GetATable(3, 6);

            //assert

            Assert.AreEqual(1, result);
        }

        [TestMethod]

        public void GetATable__()
        {


            //arrange
            DateFashion testObject = new DateFashion();

            //act
            int result = testObject.GetATable(8, 9);

            //assert

            Assert.AreEqual(2, result);
        }

    }
}
