using System.ComponentModel.DataAnnotations;
using Brainsnap.API.Extensions;
using Brainsnap.API.ViewModels;
using Brainsnap.Domain;
using Brainsnap.Services;
using Microsoft.AspNetCore.Mvc;

namespace Brainsnap.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectController : ControllerBase
{
	private readonly IProjectService _projectService;

	public ProjectController(IProjectService projectService)
	{
		_projectService = projectService;
	}

	[HttpGet]
	[Route("{name}")]
    public ActionResult<Project> GetByName([FromRoute] string name) =>
		ActionResultHelpers.GetActionResult(_projectService.Find, name);

	[HttpPut]
	public ActionResult<Project> Add([Required] AddProjectViewModel projectToAdd) =>
		ActionResultHelpers.GetActionResult(_projectService.Create, projectToAdd.Name);
}
