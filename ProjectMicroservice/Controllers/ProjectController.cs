using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectMicroservice.Domain.Entities;
using ProjectMicroservice.Infrastructure.Repository;
using ProjectMicroservice.Services.Interface;

namespace ProjectMicroservice.Controllers
{
    [ApiController]
    [Route("/v1/projects")]
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectAuthorityRepository _projectAuthorityRepository;
        private readonly IProjectService _projectService;

        
        public ProjectController(IProjectRepository projectRepository, IProjectAuthorityRepository projectAuthorityRepository, IProjectService projectService)
        {
            _projectRepository = projectRepository;
            _projectAuthorityRepository = projectAuthorityRepository;
            _projectService = projectService;
        }

        [HttpGet("{leadId}")]
        public async Task<ActionResult<List<Project>>> GetAll(int leadId)
        {
            var all = await _projectRepository.GetAllAsync(leadId);
            return Ok(all);
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] CreateProjectRequest createProjectRequest)
        {
            await _projectService.CreateProjectAsync(createProjectRequest.Name, createProjectRequest.Description, createProjectRequest.Tint, createProjectRequest.WorkspaceId, createProjectRequest.LeadId);
            return Ok();
        }

        [HttpDelete("{projectId}")]
        public async Task<IActionResult> Delete(int projectId)
        {
            await _projectRepository.DeleteAsync(projectId);
            return Ok();
        }

        [HttpPut("{projectId}")]
        public async Task<IActionResult> Update(int projectId, [FromBody] UpdateProjectRequest updatedProject)
        {
            await _projectService.UpdateProjectAsync(projectId, updatedProject.Name, updatedProject.Description, updatedProject.Tint, updatedProject.WorkspaceId, updatedProject.LeadId);
            return Ok();
        }

        [HttpGet("project/{projectId}")]
        public async Task<ActionResult<Project>> GetById(int projectId) 
        {
            var project =await _projectRepository.GetProjectByIdAsync(projectId);
            ProjectInfoDto projectInfoDto = new ProjectInfoDto() 
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                Tint = project.Tint,
                LeadId = project.LeadId
            };
            return Ok(projectInfoDto);
        }


    }
}
