using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tests
{
    [TestClass]
    public class SameFirstLastTest
    {

        [TestMethod]
        public void DifferentFirstLast()
        {
            //arrange

            SameFirstLast testObject = new SameFirstLast();

            //act

            bool result = testObject.IsItTheSame(new int[] { 1, 2, 3 });

            //assert

            Assert.AreEqual(false, result);
        }


        [TestMethod]
        public void DifferentFirstLast_()
        {
            //arrange

            SameFirstLast testObject = new SameFirstLast();

            //act

            bool result = testObject.IsItTheSame(new int[] { 1, 2, 3, 1 });

            //assert

            Assert.AreEqual(true, result);
        }


        [TestMethod]
        public void DifferentFirstLast__()
        {
            //arrange

            SameFirstLast testObject = new SameFirstLast();

            //act

            bool result = testObject.IsItTheSame(new int[] { 1, 2, 1 });

            //assert

            Assert.AreEqual(true, result);
        }
    }
}
