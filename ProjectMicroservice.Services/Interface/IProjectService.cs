using ProjectMicroservice.Application;
using ProjectMicroservice.Domain.Entities;

namespace ProjectMicroservice.Services.Interface;

public interface IProjectService
{

    Task  CreateProjectAsync(string name, string description,string tint,int workSpaceId,int leadId);
    Task UpdateProjectAsync(int id,string name,string description, string tint, int workSpaceId, int leadId);
    Task<ProjectInfoDto> ShowProjectAsync(int id);
    Task<List<ProjectInfoDto>> ShowAllProjectsAsync(int id);

}
