using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tests
{
    [TestClass]
    public class CigarPartyTest
    {

        [TestMethod]
        public void HaveParty()
        {
            //arrange
            CigarParty testObject = new CigarParty();

            //act

           bool weekendResult = testObject.HaveParty(61, true);


            //assert

            Assert.AreEqual( true, weekendResult);

        }

        [TestMethod]
        public void HaveParty__()
        {
            //arrange
            CigarParty testObject = new CigarParty();

            //act

            bool weekendResult = testObject.HaveParty(50, true);


            //assert

            Assert.AreEqual(true, weekendResult);

        }
        [TestMethod]
        public void HaveParty_()
        {
            //arrange
            CigarParty testObject = new CigarParty();

            //act

            bool weekendResult = testObject.HaveParty(30, true);


            //assert

            Assert.AreEqual(false, weekendResult);

        }

    }
}
