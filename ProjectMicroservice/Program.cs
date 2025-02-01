using Microsoft.EntityFrameworkCore;
using ProjectMicroservice.Infrastructure.Context;
using ProjectMicroservice.Infrastructure.Repository;
using ProjectMicroservice.Services;
using ProjectMicroservice.Services.Interface;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProjectMicroserviseDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectString")));

builder.Services.AddScoped<IProjectRepository,ProjectRepository >();
builder.Services.AddScoped<IProjectAuthorityRepository, ProjectAuthorityRepository>();
builder.Services.AddScoped<IProjectAuthorityService,ProjectAuthorityService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddControllers();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();