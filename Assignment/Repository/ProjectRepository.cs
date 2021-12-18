using Assignment.Models;
using Assignment.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _dbContext;

        public ProjectRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Project AddProject(Project project)
        {
            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();
            return project;
        }

        public void DeleteProject(int id)
        {
            Project project = GetProjectById(id);
            _dbContext.Projects.Remove(project);
            _dbContext.SaveChanges();
        }

        public List<Project> GetAllProjects()
        {
            return _dbContext.Projects.ToList();
        }

        public Project GetProjectById(int id)
        {
            return _dbContext.Projects.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateProject(Project project)
        {
            Project project1 = new Project();
            project1.Title = project.Title;
            project1.Duration = project.Duration;
            project1.Cost = project.Cost;
            _dbContext.Projects.Update(project1);
            _dbContext.SaveChanges();
        }
    }
}
