using System.ComponentModel.DataAnnotations;
using Brainsnap.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Brainsnap.API.Extensions;

public static class ActionResultHelpers
{
	public static ActionResult<T> GetActionResult<T>(Func<string, T> executeRequest, string name) where T : class
	{
		try
		{
			var result = executeRequest(name);
			return new OkObjectResult(result);
		}
		catch (Exception ex)
		{
			return ex.ExceptionToActionResult();
		}
	}

	private static ActionResult ExceptionToActionResult(this Exception ex) =>
		ex switch
		{
			NotFoundException => new NotFoundObjectResult(ex.Message),
			ValidationException => new BadRequestObjectResult(ex.Message),
			_ => new BadRequestResult()
		};
}
