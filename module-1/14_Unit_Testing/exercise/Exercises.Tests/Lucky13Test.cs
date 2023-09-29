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
    public class Lucky13Test
    {
        [TestMethod]
        public void GetLucky()
        {

            //arrrange
            Lucky13 testObject = new Lucky13();

            //act

            bool result = testObject.GetLucky(new int[] { 0, 2, 4 });

            //assert

            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void GetLucky_()
        {

            //arrrange
            Lucky13 testObject = new Lucky13();

            //act

            bool result = testObject.GetLucky(new int[] { 1, 2, 3 });

            //assert

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void GetLucky__()
        {

            //arrrange
            Lucky13 testObject = new Lucky13();

            //act

            bool result = testObject.GetLucky(new int[] { 1, 2, 4 });

            //assert

            Assert.AreEqual(false, result);
        }






    }
}
