using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tests
{

    [TestClass]
    public class AnimalGroupNameTest
    {



        [TestMethod]

        public void GetHerdTest()
        {


            //arrange

            AnimalGroupName testObject = new AnimalGroupName();

            //act calls the method 


            string result = testObject.GetHerd("crow");

            //assert

            Assert.AreEqual("Murder", result);
        }

        [TestMethod]
        public void GetHerdTest_()
        {

            //arrange

            AnimalGroupName testObject = new AnimalGroupName();

            //act calls the method 


            string result = testObject.GetHerd("");

            //assert

            Assert.AreEqual("unknown", result);
        }




    }
}
