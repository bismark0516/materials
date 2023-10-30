using System.Collections.Generic;
using PetInfoServer.Models;

namespace PetInfoServer.DAO
{
    public interface IUserDao
    {
        User GetUserById(int id);
        User GetUserByUsername(string username);
        User CreateUser(string username, string password);
        IList<User> GetUsers();
    }
}
