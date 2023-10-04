using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetInfo;
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
            Pets pets = new Pets();

            Pet pet = new Pet();
            pet.Name = "Bella";
            pet.Age = 6;
            pet.Type = "dog";

            //Act
            pets.AddAPet(pet);
            Pet[] result = pets.ListPets();

            //Assert
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual("Bella", result[0].Name);
        }

        [TestMethod]
        public void DeleteAPetTest()
        {
            //Arrange
            Pets pets = new Pets();

            Pet pet = new Pet();
            pet.Name = "Bella";
            pet.Age = 6;
            pet.Type = "dog";

            //Act
            pets.AddAPet(pet);
            Pet[] result = pets.ListPets();

            //Assert
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual("Bella", result[0].Name);

            int petId = result[0].Id;

            pets.DeleteAPet(petId);
            result = pets.ListPets();

            Assert.AreEqual(0, result.Length);
        }
    }
}
