using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetInfo.DAL;
using PetInfo.Models;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PetsTest
{
    [TestClass]
    public class PetTest
    {
        [TestMethod]
        public void AddAPetTest()
        {
            //Arrange
            PetDao pets = new PetDao();

            Pet pet = new Pet();
            pet.Name = "Bella";
            pet.Age = 6;
            pet.Type = "dog";

            //Act
            pets.AddPet(pet);
            List<Pet> result = pets.ListPets();

            //Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Bella", result[0].Name);
        }

        [TestMethod]
        public void DeletePetTest()
        {
            //Arrange
            PetDao pets = new PetDao();

            Pet pet = new Pet();
            pet.Name = "Bella";
            pet.Age = 6;
            pet.Type = "dog";

            //Act
            pets.AddPet(pet);
            List<Pet> result = pets.ListPets();

            //Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Bella", result[0].Name);

            int petId = result[0].Id;

            pets.DeletePet(petId);
            result = pets.ListPets();

            Assert.AreEqual(0, result.Count);
        }
    }
}
