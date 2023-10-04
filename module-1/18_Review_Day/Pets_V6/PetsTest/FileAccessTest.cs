using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsTest
{
    [TestClass]
    public class FileAccessTest
    {
        [TestMethod]
        public void GetPetsTest()
        {
            //arrange create an instance of the class
            
            FileAccess fileAccess = new FileAccess();

            //act call the method that is being tested 
            List<Pet> pets =  fileAccess.GetPets();

            //assert
            Assert.IsTrue(pets.Count > 0);
        }


        [TestMethod]
        public void WritePetsTest()
        {
            //arrange create an instance of the class

            FileAccess fileAccess = new FileAccess();

            List<Pet> pets = new List<Pet>();
            
            Pet pet = new Pet();
            pet.Name = "Bella";
            pet.Age = 6;
            pet.Type = "dog";

            pets.Add(pet);

            

            //act call the method that is being tested 
            bool result = fileAccess.WritePets(pets);

            //assert
            Assert.IsTrue(result);
        }


    }
}
