using PetInfoServer.Models;
using System.Collections.Generic;

namespace PetInfo.DAO
{
    public interface IPetDao
    {
        public List<Pet> ListPets();

        public Pet GetPet(int petId);

        public Pet AddAPet(Pet newPet);

        public Pet UpdatePet(Pet newPet);

        public bool DeleteAPet(int petId);
    }
}
