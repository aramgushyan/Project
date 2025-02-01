using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectMicroservice.Domain.Entities;
using ProjectMicroservice.Infrastructure.Repository;
using ProjectMicroservice.Services.Interface;

namespace ProjectMicroservice.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectAuthorityRepository _projectAuthorityRepository;
        private readonly IProjectService _projectService;
        public ProjectController(IProjectRepository projectRepository,IProjectAuthorityRepository projectAuthorityRepository, IProjectService projectService) 
        {
            _projectRepository = projectRepository;
            _projectAuthorityRepository = projectAuthorityRepository;
            _projectService = projectService;
        }
        [HttpGet("Projects/{leadId}")]
        public async Task<ActionResult<List<Project>>> GetAll(int leadId)
        {
             var all= await _projectRepository.GetAllAsync(leadId);
           return Ok(all);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Create([FromBody] CreateProjectRequest createProjectRequest) 
        {
            await _projectService.CreateProjectAsync(createProjectRequest.Name, createProjectRequest.Description, createProjectRequest.Tint, createProjectRequest.WorkspaceId, createProjectRequest.LeadId);
            return Ok();
        }
    }
}
