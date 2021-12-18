using Assignment.Models;
using Assignment.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public User AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public void DeleteUser(int id)
        {
            User user = GetUserById(id);
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateUser(User user)
        {
            User newUser = new User();
            newUser.Email = user.Email;
            newUser.Name = user.Name;
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }
    }
}
