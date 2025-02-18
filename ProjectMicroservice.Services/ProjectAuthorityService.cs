using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMicroservice.Application;
using ProjectMicroservice.Domain.Entities;
using ProjectMicroservice.Domain.Enums;
using ProjectMicroservice.Infrastructure.Repository;
using ProjectMicroservice.Services.Interface;

namespace ProjectMicroservice.Services
{
    public class ProjectAuthorityService:IProjectAuthorityService
    {
        private readonly IProjectAuthorityRepository _repository;
        private readonly IProjectRepository _repositoryProject;
        public ProjectAuthorityService(IProjectAuthorityRepository repository, IProjectRepository repositoryProject) 
        {
            _repository = repository;
            _repositoryProject = repositoryProject;
        }

        public async Task CreateProjectAuthorities(int projectId, UserPrivilege privilege)
        {
            var project = await _repositoryProject.GetProjectByIdAsync(projectId);
            ProjectAuthority projectAuthority = new ProjectAuthority() 
            {
               UserId = project.LeadId,
               ProjectId = projectId,
               Privilege = privilege,
            };
            projectAuthority.Project=project;
            await _repository.CreateProjectAuthoritiesAsync(projectAuthority);

        }

        public async Task<ProjectAuthorityDto> GetAuthoritiesById(int id)
        {
            var authority = await _repository.GetAuthoritiesByIdAsync(id);
            ProjectAuthorityDto authorityDto = new ProjectAuthorityDto()
            {
                UserId = authority.UserId,
                Privilege = authority.Privilege
            };
            return authorityDto;

        }

        public async Task UpdateProjectAuthorities(int projectId,int userId, UserPrivilege privilege)
        {
            ProjectAuthority projectAuthority = new ProjectAuthority()
            {
                UserId = userId,
                Privilege = privilege
            };
            await _repository.UpdateProjectAuthoritiesAsync(projectId,projectAuthority);
        }
    }
}
