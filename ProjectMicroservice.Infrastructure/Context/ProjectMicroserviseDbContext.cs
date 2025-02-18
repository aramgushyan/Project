using Microsoft.EntityFrameworkCore;
using ProjectMicroservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMicroservice.Infrastructure.Context
{
    public class ProjectMicroserviseDbContext:DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectAuthority> projectsAuthority { get; set; }

        public ProjectMicroserviseDbContext(DbContextOptions<ProjectMicroserviseDbContext> options):base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Project>().HasKey(p => p.Id);
            builder.Entity<Project>().HasMany(x => x.Authorities).WithOne(xa => xa.Project).HasForeignKey(xa=> xa.ProjectId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("ProjectString",
                    b => b.MigrationsAssembly("ProjectMicroservice.Infrastructure")); 
            }
        }
    }
}
