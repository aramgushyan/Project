using Microsoft.EntityFrameworkCore;
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
            await  _context.AddAsync(projectAuthority);
            await _context.SaveChangesAsync();
        }

        public async Task<ProjectAuthority> GetAuthoritiesByIdAsync(int id)
        {
            return await _context.projectsAuthority.FirstOrDefaultAsync(authoriti => authoriti.ProjectId == id);

        }

        public async Task UpdateProjectAuthoritiesAsync(int id,ProjectAuthority projectAuthority)
        {
            var authoriti = await GetAuthoritiesByIdAsync(id);

            authoriti.UserId =projectAuthority.UserId;
            authoriti.Privilege =projectAuthority.Privilege;

            await _context.SaveChangesAsync();
        }
    }
}
