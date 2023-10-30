﻿using PetInfo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetInfo.DAL.Interfaces
{
    public interface IOwnerDao
    {
        public List<Owner> ListOwners();

        public Owner GetOwner(int petId);

        public Owner AddAOwner(Owner newOwner);

        public Owner UpdateOwner(Owner newOwner);

        public bool DeleteAOwner(int petId);
    }
}
