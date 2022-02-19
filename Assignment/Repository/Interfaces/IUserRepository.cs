using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Repository.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();

        User GetUserById(int id);

        bool AddUser(User user);

        void DeleteUser(int id);

        void UpdateUser(User user);

    }
}
