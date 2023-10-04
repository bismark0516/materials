using System;
using System.Collections.Generic;

namespace PetInfo
{
    public class Pets
    {
        private List<Pet> pets = new List<Pet>();

        public Pet[] ListPets()
        {
            return pets.ToArray();
        }

        public bool AddAPet(Pet newPet)
        {
            //assigns value THEN increments afterward
            newPet.Id = Pet.nextPetId++; 

            pets.Add(newPet);
            return true;
        }

        public bool DeleteAPet(int petId)
        {
            //loop throught list to delete pet
            bool result = false;

            for(int i = 0; i < pets.Count; i ++)
            {
                if (pets[i].Id == petId)
                {
                    pets.RemoveAt(i);
                    result = true;
                    break;
                }
            }

            return result;
        }
    }
}
