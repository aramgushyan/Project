using ProjectMicroservice.Domain.Entities;
using ProjectMicroservice.Infrastructure.Repository;
using ProjectMicroservice.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMicroservice.Services
{
    public class ProjectService:IProjectService
    {
        private readonly IProjectRepository _repositoyry;
        public ProjectService(IProjectRepository repository) 
        {
            _repositoyry = repository;
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
            await _repositoyry.CreateProjectAsync(project);
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
            await _repositoyry.UpdateProjectAsync(project);
        }
    }
}
