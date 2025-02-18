using ProjectMicroservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMicroservice.Infrastructure.Repository
{
    public interface IProjectAuthorityRepository
    {
        Task <ProjectAuthority> GetAuthoritiesByIdAsync(int id);
        
        Task UpdateProjectAuthoritiesAsync(int id,ProjectAuthority projectAuthority);
        Task CreateProjectAuthoritiesAsync(ProjectAuthority projectAuthority);
    }
}
