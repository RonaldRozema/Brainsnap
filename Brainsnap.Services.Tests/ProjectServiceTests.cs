using System.ComponentModel.DataAnnotations;
using Brainsnap.DataAccess;
using Brainsnap.Domain;
using Brainsnap.Domain.Entities;
using Brainsnap.Domain.Exceptions;
using FluentAssertions;
using Moq;

namespace Brainsnap.Services.Tests;

public class ProjectServiceTests
{
	[Fact]
	public void Find_GivenANameThatExists_ReturnProjectWithGivenName()
	{
		var projectRepoMock = new Mock<IProjectRepository>();

		var name = "existingProject";
		var sut = new ProjectService(projectRepoMock.Object);

		var expectedFoundProject = new Project(name).ToEntity();
		projectRepoMock.Setup(r => r.Find(It.Is<string>(n => n == name))).Returns(expectedFoundProject);

		var result = sut.Find(name);

		result.Should().NotBeNull();
		result!.Name.Should().Be(name);
	}

	[Fact]
	public void Find_GivenANameThatDoesntExist_ReturnsANullReference()
	{
		var projectRepoMock = new Mock<IProjectRepository>();

		var name = "nonExistingProject";
		var sut = new ProjectService(projectRepoMock.Object);

        projectRepoMock.Setup(r => r.Find(It.Is<string>(n => n == name))).Returns(null as ProjectEntity);

		var act = () => sut.Find(name);

		act.Should().Throw<NotFoundException>();
	}

	[Fact]
	public void Add_GivenProjectNameWithLessThen50Characters_ShouldStore()
	{
		var projectRepoMock = new Mock<IProjectRepository>();
		var name = "lessThen50Characters";
		var sut = new ProjectService(projectRepoMock.Object);

		projectRepoMock.Setup(r => r.Add(It.IsAny<Project>())).Returns(new ProjectEntity(name, DateTime.Now));

		var result = sut.Create(name);

		result.Name.Should().Be(name);
		projectRepoMock.Verify(r => r.Add(It.IsAny<Project>()), Times.Once);
		projectRepoMock.Verify(r => r.Save(), Times.Once);
	}

	[Fact]
	public void Add_GivenProjectNameWithExactly50Characters_ShouldStore()
	{
        var projectRepoMock = new Mock<IProjectRepository>();
        var name = "50CharactersExcactlyqwertyuiopasdfghjklzxcvbnm1234";
        var sut = new ProjectService(projectRepoMock.Object);

        projectRepoMock.Setup(r => r.Add(It.IsAny<Project>())).Returns(new ProjectEntity(name, DateTime.Now));

        var result = sut.Create(name);

        result.Name.Should().Be(name);
        projectRepoMock.Verify(r => r.Add(It.IsAny<Project>()), Times.Once);
        projectRepoMock.Verify(r => r.Save(), Times.Once);
    }

	[Fact]
	public void Add_GivenProjectNameLongerThen50Characters_ShouldNotStore()
	{
        var projectRepoMock = new Mock<IProjectRepository>();
        var name = "MoreThen50Charactersqwertyuiopasdfghjklzxcvbnm1234567890po";
        var sut = new ProjectService(projectRepoMock.Object);

        var act = () => sut.Create(name);

		act.Should().Throw<ValidationException>();
        projectRepoMock.Verify(r => r.Add(It.IsAny<Project>()), Times.Never);
        projectRepoMock.Verify(r => r.Save(), Times.Never);
    }
}
