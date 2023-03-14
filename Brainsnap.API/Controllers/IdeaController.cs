using Brainsnap.API.Extensions;
using Brainsnap.Domain;
using Brainsnap.Services;
using Microsoft.AspNetCore.Mvc;

namespace Brainsnap.API.Controllers;

[ApiController]
[Route("[controller]")]
public class IdeaController : ControllerBase
{
	private readonly IIdeaService _ideaService;

	public IdeaController(IIdeaService ideaService)
	{
		_ideaService = ideaService;
	}

	[HttpPost]
	public ActionResult<Idea> Add([FromBody] Idea idea) =>
		ActionResultHelpers.GetActionResult(_ideaService.Add, idea);
}
