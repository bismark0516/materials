using PetInfo.DataAccess;
using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;

namespace PetInfo
{
    public class Pets
    {
        private FileAccess fileAccess = new FileAccess();

        public Pet[] ListPets()
        {
            List<Pet> pets = fileAccess.ReadFile();
            return pets.ToArray();
        }

        public Pet GetPet(int petId)
        {
            Pet result = new Pet();
            List<Pet> pets = fileAccess.ReadFile();
            foreach (Pet pet in pets)
            {
                if (petId == pet.Id)
                {
                    result = pet;
                    break;
                }
            }
            return result;
        }

        public void AddAPet(Pet newPet)
        {
            //assigns value THEN increments afterward
            newPet.Id = Pet.nextPetId++;

            List<Pet> pets = fileAccess.ReadFile();

            pets.Add(newPet);

            fileAccess.WriteFile(pets);
            return;
        }

        public void UpdatePet(Pet newPet)
        {
            //get the pets
            List<Pet> pets = fileAccess.ReadFile();

            //find the one to be updated
            for (int i = 0; i < pets.Count; i++)

            {
                if (newPet.Id == pets[i].Id)
                {
                    pets[i] = newPet;
                    break;
                }
            }

            // write the file back out
            fileAccess.WriteFile(pets);
            return;
        }

        public void DeleteAPet(int petId)
        {
            List<Pet> pets = fileAccess.ReadFile();

            //loop throught list to delete pet

            int beforeCount = pets.Count;

            for (int i = 0; i < pets.Count; i++)
            {
                if (pets[i].Id == petId)
                {
                    pets.RemoveAt(i);
                    break;
                }
            }

            int afterCount = pets.Count;

            //nothing deleted - no need to write file
            if (beforeCount == afterCount)
            {
                return;
            }

            fileAccess.WriteFile(pets);

            return;
        }
    }
}
