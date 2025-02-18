using Microsoft.EntityFrameworkCore;
using ProjectMicroservice.Infrastructure.Context;
using ProjectMicroservice.Infrastructure.Repository;
using ProjectMicroservice.Services;
using ProjectMicroservice.Services.Interface;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProjectMicroserviseDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectString")));

builder.Services.AddScoped<IProjectRepository,ProjectRepository >();
builder.Services.AddScoped<IProjectAuthorityRepository, ProjectAuthorityRepository>();
builder.Services.AddScoped<IProjectAuthorityService,ProjectAuthorityService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

var app = builder.Build();
//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

app.MapControllers();

app.Run();