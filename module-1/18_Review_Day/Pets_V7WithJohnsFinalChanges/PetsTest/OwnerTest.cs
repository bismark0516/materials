using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetsTest
{

    //create a Owner object and test that  the object is not null
    [TestClass]
    public class OwnerTest
    {
        [TestMethod]
        public void OwnerObjectTest()
        {
            string email = "drew123@gmail.com";
            string name = "Drew";
            Owner testObject = new Owner(name,email);

            Assert.IsNotNull(testObject);
        }
    }
}
