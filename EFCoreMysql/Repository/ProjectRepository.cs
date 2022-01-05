using EFCoreMysql.DBContexts;
using EFCoreMysql.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMysql.Repository
{
    public interface IProjectRepository
    {
        Task<Project> CreateProjectAsync(string projectName, string description);
    }
    public class ProjectRepository : IProjectRepository
    {
        private readonly MyDBContext _dbContext;
        public ProjectRepository(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Project> CreateProjectAsync(string projectName, string description)
        {
            Project newProject = Project.Create(projectName,description).Value;
            await _dbContext.AddAsync<Project>(newProject);

            return newProject;
        }
    }
}
