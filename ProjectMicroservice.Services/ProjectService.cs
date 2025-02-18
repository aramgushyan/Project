using ProjectMicroservice.Domain.Entities;
using ProjectMicroservice.Infrastructure.Repository;
using ProjectMicroservice.Services.Interface;
using ProjectMicroservice.Application;

namespace ProjectMicroservice.Services
{
    public class ProjectService:IProjectService
    {
        private readonly IProjectRepository _repository;
        public ProjectService(IProjectRepository repository) 
        {
            _repository = repository;
        }

        public async Task CreateProjectAsync(string name, string description, string tint, int workSpaceId, int leadId)
        {
            Project project = new Project()
            {
                Name = name,
                Description = description,
                Tint = tint,
                WorkSpaceId = workSpaceId,
                LeadId = leadId
            };
            await _repository.CreateProjectAsync(project);
        }

        public async  Task<List<ProjectInfoDto>> ShowAllProjectsAsync(int id)
        {
            var all = await _repository.GetAllAsync(id);
            List<ProjectInfoDto> results = new List<ProjectInfoDto>();
            foreach (var project in all) 
            {
                results.Add(new ProjectInfoDto()
                {
                    Name = project.Name,
                    Description = project.Description,
                    Tint = project.Tint,
                    LeadId = project.LeadId
                });
            }
            return results;
        }

        public async Task<ProjectInfoDto> ShowProjectAsync(int id)
        {
            var project = await _repository.GetProjectByIdAsync(id);
            ProjectInfoDto projectInfoDto=null;
            if (project != null)
            {
                projectInfoDto = new ProjectInfoDto()
                {
                    Id = project.Id,
                    Name = project.Name,
                    Description = project.Description,
                    Tint = project.Tint,
                    LeadId = project.LeadId
                };
            }
            return projectInfoDto;
        }

        public async Task UpdateProjectAsync(int id, string name, string description, string tint, int workSpaceId, int leadId)
        {
            Project project = new Project()
            {
                Id = id,
                Name = name,
                Description = description,
                Tint = tint,
                WorkSpaceId = workSpaceId,
                LeadId = leadId
            };
            await _repository.UpdateProjectAsync(project);
        }
    }
}
