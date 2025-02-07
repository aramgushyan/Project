using ProjectMicroservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMicroservice.Infrastructure.Repository
{
    public interface IProjectRepository
    {
        Task<Project> GetProjectByIdAsync(int id);
        Task<List<Project>> GetAllAsync(int leadId);
        Task CreateProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
        Task DeleteAsync(int id);
        Task AddAuthorityAsync(int id,ProjectAuthority projectAuthority);
    }
}