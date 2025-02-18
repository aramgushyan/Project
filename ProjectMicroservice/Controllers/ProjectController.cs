using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectMicroservice.Domain.Entities;
using ProjectMicroservice.Infrastructure.Repository;
using ProjectMicroservice.Services.Interface;
using ProjectMicroservice.Application;
using ProjectMicroservice.Services;
using ProjectMicroservice.Domain.Enums;
using Projectmicroservice.Application.Models;

namespace ProjectMicroservice.Controllers
{
    [ApiController]
    [Route("v1/projects")]
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectAuthorityRepository _projectAuthorityRepository;
        private readonly IProjectAuthorityService _projectAuthorityService;
        private readonly IProjectService _projectService;

        
        public ProjectController(IProjectRepository projectRepository, IProjectAuthorityRepository projectAuthorityRepository, IProjectService projectService, IProjectAuthorityService projectAuthorityService)
        {
            _projectRepository = projectRepository;
            _projectAuthorityRepository = projectAuthorityRepository;
            _projectService = projectService;
            _projectAuthorityService = projectAuthorityService;
        }

        [HttpGet("{leadId}")]
        public async Task<ActionResult<List<Project>>> GetAll(int leadId)
        {
            var all = await _projectService.ShowAllProjectsAsync(leadId);
            if (all == null) 
            {
                return NotFound();
            }
            return Ok(all);
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] CreateProjectRequest createProjectRequest)
        {
            await _projectService.CreateProjectAsync(createProjectRequest.Name, createProjectRequest.Description, createProjectRequest.Tint, createProjectRequest.WorkspaceId, createProjectRequest.LeadId);
            return NoContent();
        }

        [HttpDelete("{projectId}")]
        public async Task<IActionResult> Delete(int projectId)
        {
            if (await _projectService.ShowProjectAsync(projectId) == null)
            {
                return NotFound();
            }
            await _projectRepository.DeleteAsync(projectId);
            return NoContent();
        }

        [HttpPut("{projectId}")]
        public async Task<IActionResult> Update(int projectId, [FromBody] UpdateProjectRequest updatedProject)
        {
            if (await _projectService.ShowProjectAsync(projectId) == null) 
            {
                return NotFound();
            }
            await _projectService.UpdateProjectAsync(projectId, updatedProject.Name, updatedProject.Description, updatedProject.Tint, updatedProject.WorkspaceId, updatedProject.LeadId);
            return NoContent();
        }

        [HttpGet("project/{projectId}")]
        public async Task<ActionResult<Project>> GetById(int projectId) 
        {
            var projectInfoDto= await _projectService.ShowProjectAsync(projectId);
            if (projectInfoDto == null) 
            {
                return NotFound();
            }
            return Ok(projectInfoDto);
        }

        [HttpPost("{projectid}/authorities")]
        public async Task<IActionResult> CreateAuthorities(int projectId,[FromBody]UserPrivilege userPrivilege) 
        {
            await _projectAuthorityService.CreateProjectAuthorities(projectId,userPrivilege);
            if (await _projectService.ShowProjectAsync(projectId) == null) 
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("{projectid}/authorities")]
        public async Task<ActionResult<ICollection<Project>>> GetAuthoritiesById(int projectId)
        {
            var authoritiInfoDto = await _projectAuthorityService.GetAuthoritiesById(projectId);
            if (authoritiInfoDto == null)
            {
                return NotFound();
            }
            return Ok(authoritiInfoDto);
        }

        [HttpPut("{projectId}/authorities")]
        public async Task<IActionResult> UpdateAuthorities(int projectId, [FromBody] UpdateAuthorityRequest updateAuthority)
        {
            if (await _projectService.ShowProjectAsync(projectId) == null || await _projectAuthorityService.GetAuthoritiesById(projectId) == null)
            {
                return NotFound();
            }
            await _projectAuthorityService.UpdateProjectAuthorities(projectId, updateAuthority.UserId, updateAuthority.Privilege);
           
            return NoContent();
        }

    }
}
