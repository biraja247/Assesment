using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Repository.Interfaces
{
    public interface IUserTaskRepository
    {
        List<UserTask> GetAllTasks();

        UserTask GetTasksById(int id);

        UserTask AddTask(UserTask utask);

        void DeleteTask(int id);

        void UpdateTask(UserTask utask);
    }
}
