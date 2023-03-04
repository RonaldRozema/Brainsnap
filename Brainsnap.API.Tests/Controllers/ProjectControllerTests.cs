using System.ComponentModel.DataAnnotations;
using Brainsnap.API.Controllers;
using Brainsnap.API.ViewModels;
using Brainsnap.Domain;
using Brainsnap.Domain.Exceptions;
using Brainsnap.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Brainsnap.API.Tests.Controllers;

public class ProjectControllerTests
{
	[Fact]
	public void GetByName_GivenAnExistingName_ShouldReturnOkResult()
	{
		var projectServiceMock = new Mock<IProjectService>();

		var name = "existingName";
		var existingProject = new Project(name);
		var sut = new ProjectController(projectServiceMock.Object);

		projectServiceMock.Setup(s => s.Find(It.Is<string>(n => n == name))).Returns(existingProject);

		var actionResult = sut.GetByName(name);

		var result = actionResult.Result as OkObjectResult;
		result.Should().NotBeNull();
	}

	[Fact]
	public void GetByName_GivenANonExistingName_ShouldReturnNotFoundResult()
	{
        var projectServiceMock = new Mock<IProjectService>();

        var name = "nonExistingName";
        var sut = new ProjectController(projectServiceMock.Object);

        projectServiceMock.Setup(s => s.Find(It.Is<string>(n => n == name))).Throws(new NotFoundException(string.Empty));

        var actionResult = sut.GetByName(name);

		var result = actionResult.Result as NotFoundObjectResult;
		result.Should().NotBeNull();
    }

	[Fact]
	public void Add_GivenAValidNameToAdd_ShouldReturnOkResult()
	{
		var projectServiceMock = new Mock<IProjectService>();

		var name = "test";
		var addProject = new AddProjectViewModel(name);
		var addedProject = new Project(name);
		var sut = new ProjectController(projectServiceMock.Object);

		projectServiceMock.Setup(s => s.Create(It.Is<string>(n => n == addProject.Name))).Returns(addedProject);

		var actionResult = sut.Add(addProject);

		var result = actionResult.Result as OkObjectResult;
		result.Should().NotBeNull();
        projectServiceMock.Verify(s => s.Create(It.Is<string>(n => n == addProject.Name)), Times.Once);
    }

	[Fact]
	public void Add_GivenAnInvalidName_ShouldReturnBadRequestResult()
	{
        var projectServiceMock = new Mock<IProjectService>();

        var name = "wnlutywivhligkbghqwtxachwpkkamzqeemotekqmcushfxghdi";
        var addProject = new AddProjectViewModel(name);
        var addedProject = new Project(name);
        var sut = new ProjectController(projectServiceMock.Object);

        projectServiceMock.Setup(s => s.Create(It.Is<string>(n => n == addProject.Name))).Throws<ValidationException>();

        var actionResult = sut.Add(addProject);

        var result = actionResult.Result as BadRequestObjectResult;
        result.Should().NotBeNull();
        projectServiceMock.Verify(s => s.Create(It.IsAny<string>()), Times.Once);
    }
}
