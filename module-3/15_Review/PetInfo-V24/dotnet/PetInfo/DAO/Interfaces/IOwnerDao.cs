using PetInfo.Models;
using System.Collections.Generic;

namespace PetInfo.DAO.Interfaces
{
    public interface IOwnerDao
    {
        public List<Owner> ListOwners();
        public Owner AddOwner(Owner newOwner);
    }
}
