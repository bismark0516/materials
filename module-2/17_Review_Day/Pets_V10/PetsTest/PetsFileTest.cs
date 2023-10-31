using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetInfo.DAL;
using PetInfo.Models;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PetsTest
{
    [TestClass]
    public class PetsFileTest
    {
        [TestMethod]
        public void AddAPetTest()
        {
            //Arrange
            PetFileDao pets = new PetFileDao();

            List<Pet> result = pets.ListPets();
            int beforeCount = result.Count;

            Pet pet = new Pet();
            pet.Name = "Bella";
            pet.Age = 6;
            pet.Type = "dog";

            //Act
            pets.AddAPet(pet);

            result = pets.ListPets();
            int afterCount = result.Count;

            //Assert
            Assert.AreEqual(beforeCount + 1, afterCount);
        }

        [TestMethod]
        public void DeleteAPetTest()
        {
            //Arrange
            PetFileDao pets = new PetFileDao();

            Pet pet = new Pet();
            pet.Name = "Bella";
            pet.Age = 6;
            pet.Type = "dog";

            //Act
            pets.AddAPet(pet);
            List<Pet> result = pets.ListPets();
            int beforeCount = result.Count;

            int petId = result[beforeCount-1].Id;

            pets.DeleteAPet(petId);
            result = pets.ListPets();
            int afterCount = result.Count;

            //Assert
            Assert.AreEqual(beforeCount-1, afterCount);
        }
    }
}
