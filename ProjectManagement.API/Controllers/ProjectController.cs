using Microsoft.AspNetCore.Mvc;
using ProjectManagement.API.Common;
using ProjectManagement.API.Controllers.Base;
using ProjectManagement.Application.Interfaces.Services;
using ProjectManagement.Domain.Entities;


namespace ProjectManagement.API.Controllers;

public class ProjectController : BaseController
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Project>> Get(Guid id)
    {
        var result = await _projectService.Get(id);
        return new CustomResult<Project>(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Project>>> GetAll()
    {
        var result = await _projectService.GetAll();
        return new CustomResult<IEnumerable<Project>>(result);
    }

    [HttpPost]
    public async Task<IActionResult> Save(Project project)
    {
        await _projectService.Save(project);
        return new CustomResult<string>("Saved Successfully");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _projectService.Delete(id);
        return new CustomResult<string>("Deleted Successfully");
    }
}
