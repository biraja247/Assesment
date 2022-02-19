using Assignment.Models;
using Assignment.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Repository
{
    public class UserTaskRepository : IUserTaskRepository
    {
        private readonly AppDbContext _dbContext;

        public UserTaskRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool AddTask(UserTask utask)
        {
            try
            {
                _dbContext.UserTasks.Add(utask);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

           
        }

        public void DeleteTask(int id)
        {
            UserTask utask = GetTasksById(id);
            _dbContext.UserTasks.Remove(utask);
            _dbContext.SaveChanges();
        }

        public List<UserTask> GetAllTasks()
        {
            return _dbContext.UserTasks.ToList();
        }

        public UserTask GetTasksById(int id)
        {
            return _dbContext.UserTasks.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateTask(UserTask utask)
        {
            UserTask uTask1 = new UserTask();
            uTask1.Status = utask.Status;
            uTask1.TaskName = utask.TaskName;
            _dbContext.UserTasks.Update(uTask1);
            _dbContext.SaveChanges();
        }
    }
}
