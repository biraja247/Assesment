using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Repository.Interfaces
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetAllProjects();

        Project GetProjectById(int id);

        bool AddProject(Project project);

        void DeleteProject(int id);

        void UpdateProject(Project project);
    }
}
