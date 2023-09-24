using DataType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pets
{
    public class PetInfo
    {
       
        private List<Pet> pets = new List<Pet>();

        public bool AddPet(Pet pet)
        {
            pets.Add(pet);

            return true;
        }

        public Pet[] GetPets()
        {
            return pets.ToArray();
        }
    }
}
