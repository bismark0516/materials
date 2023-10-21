using PetInfo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetInfo.DAL.Interfaces
{
    internal interface IOwnerDao
    {
        public List<Owner> ListOwners();

        public Owner GetOwner(int ownerId);

        public Owner AddOwner(Owner newOwner);

        public Owner UpdateOwner(Owner newOwner);

        public bool DeleteOwner(int ownerId);
    }
}
