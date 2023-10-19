using PetInfo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetInfo.DAL.Interfaces
{
    internal interface IPetDao
    {
        public List<Pet> ListPets();

        public Pet GetPet(int petId);

        public Pet AddPet(Pet newPet);

        public Pet UpdatePet(Pet newPet);

        public bool DeletePet(int petId);
    }
}
