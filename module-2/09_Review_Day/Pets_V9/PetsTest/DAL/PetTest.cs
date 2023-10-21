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
            //arrange
            dao.DeletePet(1);
            List<Pet> result = dao.ListPets();

            //assert
            Assert.AreEqual(3, result.Count);


        }
        [TestMethod]

        public void AddPetTest()
        {
            Pet newPet = new Pet();

            newPet.Name = "newPet";
            newPet.Type = "Dog";
            newPet.Age = 1;
            dao.AddPet(newPet);

            List<Pet> result = dao.ListPets();

            Assert.AreEqual(5, result.Count);

        }
        [TestMethod]

        public void UpdatePetTest()
        {
            Pet pet = new Pet();

            pet.Name = "Updated Pet";
            pet.Type = "Dog";
            pet.Age = 3;
            pet.Id = 1;

            Pet updatedPet = dao.UpdatePet(pet);

            Assert.IsNotNull(updatedPet);

            AssertPetsMatch(updatedPet, pet);



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
