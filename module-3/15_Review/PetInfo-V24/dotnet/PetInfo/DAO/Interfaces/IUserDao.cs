using System.Collections.Generic;
using PetInfo.Models;

namespace PetInfo.DAO.Interfaces
{
    public interface IUserDao
    {
        IList<User> GetUsers();
        User GetUserById(int id);
        User GetUserByUsername(string username);
        User CreateUser(string username, string password, string role);
    }
}
