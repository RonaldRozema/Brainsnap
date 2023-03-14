using System.ComponentModel.DataAnnotations;
using Brainsnap.API.Controllers;
using Brainsnap.Domain;
using Brainsnap.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Brainsnap.API.Tests.Controllers;

public class IdeaControllerTests
{
	[Fact]
	public void Add_GivenAValidIdeaModel_ShouldReturnOkResult()
	{
		var ideaServiceMock = new Mock<IIdeaService>();

		var idea = new Idea("New idea", string.Empty);
		var sut = new IdeaController(ideaServiceMock.Object);

		ideaServiceMock.Setup(s => s.Create(It.IsAny<Idea>())).Returns(idea);

		var actionResult = sut.Add(idea);

		var result = actionResult.Result as OkObjectResult;
		result.Should().NotBeNull();
	}

	[Fact]
	public void Add_GivenAnInvalidIdeaModel_ShouldReturnBadRequest()
	{
		var ideaServiceMock = new Mock<IIdeaService>();

		var idea = new Idea(string.Empty, string.Empty);
		var sut = new IdeaController(ideaServiceMock.Object);

		ideaServiceMock.Setup(s => s.Create(It.IsAny<Idea>())).Throws(new ValidationException());

		var actionResult = sut.Add(idea);

		var result = actionResult.Result as BadRequestObjectResult;
		result.Should().NotBeNull();
	}
}
