using System.Threading.Tasks;
using EFCoreMysql.Domain;
using EFCoreMysql.Models.Request;
using EFCoreMysql.Models.Response;
using EFCoreMysql.Repository;

namespace EFCoreMysql.Services.Commands
{
    public interface ICreateProjectCommand
    {
        Task<ProjectViewModel> CreateProjectAsync(CreateProjectRequest request);
    }
    public class CreateProjectCommand : ICreateProjectCommand
    {
        private readonly IProjectRepository _projectRepository;
        public CreateProjectCommand(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<ProjectViewModel> CreateProjectAsync(CreateProjectRequest request)
        {
            ProjectViewModel project = new ProjectViewModel(await _projectRepository.CreateProjectAsync(request.ProjectName,request.ProjectDescription));
            return project;
           
        }
    }
}
