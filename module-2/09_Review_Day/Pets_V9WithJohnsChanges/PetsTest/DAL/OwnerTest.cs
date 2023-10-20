using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetInfo.Models;
using PetTest.DAO;

namespace PetsTest.DAL
{

    //create a Owner object and test that  the object is not null
    [TestClass]
    public class OwnerTest: BaseDaoTests
    {
        [TestMethod]
        public void OwnerObjectTest()
        {
            string email = "drew123@gmail.com";
            string name = "Drew";
            Owner testObject = new Owner(name, email);

            Assert.IsNotNull(testObject);
        }
    }
}
