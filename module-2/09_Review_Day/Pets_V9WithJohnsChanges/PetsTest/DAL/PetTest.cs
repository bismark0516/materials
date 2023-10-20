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
        public void Create_Pet_Object_Test()
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

        [TestMethod]
        public void DeletePetTest()
        {
            //Act
            dao.DeletePet(1);
            List<Pet> result = dao.ListPets();

            //Assert
            Assert.AreEqual(3, result.Count);

        }

        [TestMethod]
        public void AddPetTest()
        {
            //Arrange
            Pet pet = new Pet();
            pet.Age = 1;
            pet.Name = "Houdini";
            pet.Type = "Dog";


            //Act
            dao.AddPet(pet);

            List<Pet> result = dao.ListPets();

            //Assert
            Assert.AreEqual(5, result.Count);
        }

        [TestMethod]
        public void UpdatePetTest()
        {
            Pet testPet = new Pet();
            testPet.Id = 4;
            testPet.Name = "Ed";
            testPet.Age = 8;
            testPet.Type = "Cat";

            Pet actualPet = dao.UpdatePet(testPet);

            Assert.IsNotNull(actualPet,"Method return a null, rather than an object of type Pet");

            AssertPetsMatch(testPet, actualPet);
        }

        private void AssertPetsMatch(Pet expected, Pet actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Age, actual.Age);
            Assert.AreEqual(expected.Type, actual.Type);
        }

    }
}
