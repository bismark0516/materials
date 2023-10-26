﻿using PetInfo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetInfo.DAL.Interfaces
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
