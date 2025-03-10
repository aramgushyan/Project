﻿using Microsoft.EntityFrameworkCore;
using ProjectMicroservice.Domain.Entities;
using ProjectMicroservice.Infrastructure.Context;
using ProjectMicroservice.Domain.Entities;

namespace ProjectMicroservice.Infrastructure.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProjectMicroserviseDbContext _context;
        public ProjectRepository(ProjectMicroserviseDbContext context) 
        {
            _context = context;
        }

        public  async Task CreateProjectAsync(Project project)
        {
            await _context.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var project = await GetProjectByIdAsync(id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync() ;
        }

        public async Task<List<Project>> GetAllAsync(int leadId)
        {
            return await _context.Projects.Where(x=> x.LeadId==leadId).ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task UpdateProjectAsync(Project project)
        {
             _context.Update(project);
            await _context.SaveChangesAsync();
        }
    }
}
