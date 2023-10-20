using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetInfo.DAL;
using PetInfo.Models;
using PetTest.DAO;
using System.Collections.Generic;
using System.Transactions;

namespace PetsTest.DAL
{
    [TestClass]
    public class PetTest : BaseDaoTests
    {
        PetDao dao;

        [TestInitialize]
        public virtual void Init()
        {
            dao = new PetDao(connectionString);
        }

        [TestMethod]
        public void Careate_Pet_Object_Test()
        {
            //Arrange
            Pet pets = new Pet();

            Pet pet = new Pet();
            pet.Name = "Bella";
            pet.Age = 6;
            pet.Type = "dog";

            //Assert
            Assert.AreEqual(6, pet.Age);
            Assert.AreEqual("Bella", pet.Name);
        }

        [TestMethod]
        public void GetPets()
        {
            List<Pet> pets = dao.ListPets();

            Assert.AreEqual(4, pets.Count);
        }
    }
}
