using ProjectMicroservice.Domain.Entities;
using ProjectMicroservice.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMicroservice.Infrastructure.Repository
{
    public class ProjectAuthorityRepository : IProjectAuthorityRepository
    {
         private readonly ProjectMicroserviseDbContext _context;
        public ProjectAuthorityRepository(ProjectMicroserviseDbContext context)
        {
            _context = context;
        }

        public async Task CreateProjectAuthoritiesAsync(ProjectAuthority projectAuthority)
        {
            _context.AddAsync(projectAuthority);
            await _context.SaveChangesAsync();
        }

        public async Task<ProjectAuthority> GetAuthoritiesByIdAsync(int id)
        {
            return await _context.projectsAuthority.FindAsync(id);
        }

        public async Task UpdateProjectAuthoritiesAsync(ProjectAuthority projectAuthority)
        {
            _context.Update(projectAuthority);
            await _context.SaveChangesAsync();
        }
    }
}
