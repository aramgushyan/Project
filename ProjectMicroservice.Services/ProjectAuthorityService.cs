using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMicroservice.Domain.Entities;
using ProjectMicroservice.Domain.Enums;
using ProjectMicroservice.Infrastructure.Repository;
using ProjectMicroservice.Services.Interface;

namespace ProjectMicroservice.Services
{
    public class ProjectAuthorityService:IProjectAuthorityService
    {
        private readonly IProjectAuthorityRepository _repository;
        public ProjectAuthorityService(IProjectAuthorityRepository repository) 
        {
            _repository = repository;
        }

        public async Task CreateProjectAuthorities(int userId, UserPrivilege privilege)
        {
            ProjectAuthority projectAuthority = new ProjectAuthority() 
            {
               UserId = userId,
               Privilege = privilege
            };
            await _repository.CreateProjectAuthoritiesAsync(projectAuthority);
        }

        public async Task UpdateProjectAuthorities(int userId, UserPrivilege privilege)
        {
            ProjectAuthority projectAuthority = new ProjectAuthority()
            {
                UserId = userId,
                Privilege = privilege
            };
            await _repository.UpdateProjectAuthoritiesAsync(projectAuthority);
        }
    }
}
