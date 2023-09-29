using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tests
{
    [TestClass]
    public class MaxEnd3Test
    {

        [TestMethod]
        public void MakeArray()
        {
            //arrange
            MaxEnd3 testObject = new MaxEnd3();

            // act

            int[] result = testObject.MakeArray(new int[] { 1, 2, 3 });

            //assert
            CollectionAssert.AreEqual(new int[] { 3, 3, 3 }, result);
        }
        [TestMethod]
        public void MakeArray_()
        {
            //arrange
            MaxEnd3 testObject = new MaxEnd3();

            // act

            int[] result = testObject.MakeArray(new int[] { 11, 5, 9 });

            //assert
            CollectionAssert.AreEqual(new int[] { 11, 11, 11 }, result);
        }
        [TestMethod]
        public void MakeArray__()
        {
            //arrange
            MaxEnd3 testObject = new MaxEnd3();

            // act

            int[] result = testObject.MakeArray(new int[] { 2, 11, 3 });

            //assert
            CollectionAssert.AreEqual(new int[]{ 3, 3, 3 }, result);
        }

    }
}
