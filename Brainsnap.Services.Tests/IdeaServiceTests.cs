using System.ComponentModel.DataAnnotations;
using Brainsnap.DataAccess;
using Brainsnap.Domain;
using Brainsnap.Domain.Entities;
using FluentAssertions;
using Moq;

namespace Brainsnap.Services.Tests;

public class IdeaServiceTests
{
	[Fact]
	public void Add_GivenTheNameHasLessThen50Characters_ShouldAddIdea()
	{
		var ideaRepositoryMock = new Mock<IIdeaRepository>();

		var ideaToAdd = CreateIdea(15, 15);
		var ideaEntityToAdd = new IdeaEntity(2, ideaToAdd.Name, ideaToAdd.Description ?? string.Empty, DateTimeOffset.Now);
		var sut = new IdeaService(ideaRepositoryMock.Object);

		ideaRepositoryMock.Setup(r => r.Add(It.IsAny<IdeaEntity>())).Returns(ideaEntityToAdd);

		var result = sut.Add(ideaToAdd);

		result.Name.Should().Be(ideaToAdd.Name);
		result.Description.Should().Be(ideaToAdd.Description);
		result.Id.Should().Be(ideaEntityToAdd.Id);
		result.DateAdded.Should().Be(ideaEntityToAdd.DateAdded);

		ideaRepositoryMock.Verify(r => r.Add(It.IsAny<IdeaEntity>()), Times.Once);
        ideaRepositoryMock.Verify(r => r.Save(), Times.Once);
	}

	[Fact]
	public void Add_GivenTheNameHasExactly50Characters_ShouldAddIdea()
	{
		var ideaRepositoryMock = new Mock<IIdeaRepository>();
		var ideaToAdd = CreateIdea(50, 15);
        var ideaEntityToAdd = new IdeaEntity(2, ideaToAdd.Name, ideaToAdd.Description ?? string.Empty, DateTimeOffset.Now);
        var sut = new IdeaService(ideaRepositoryMock.Object);

        ideaRepositoryMock.Setup(r => r.Add(It.IsAny<IdeaEntity>())).Returns(ideaEntityToAdd);

        var result = sut.Add(ideaToAdd);

		result.Name.Should().Be(ideaToAdd.Name);
		result.Description.Should().Be(ideaToAdd.Description);
		result.Id.Should().Be(ideaEntityToAdd.Id);
		result.DateAdded.Should().Be(ideaEntityToAdd.DateAdded);

        ideaRepositoryMock.Verify(r => r.Add(It.IsAny<IdeaEntity>()), Times.Once);
        ideaRepositoryMock.Verify(r => r.Save(), Times.Once);
    }

	[Fact]
	public void Add_GivenTheNameHasMoreThen50Characters_ShouldThrowException()
	{
        var ideaRepositoryMock = new Mock<IIdeaRepository>();

        var ideaToAdd = CreateIdea(51, 15);
        var sut = new IdeaService(ideaRepositoryMock.Object);

		var act = () => sut.Add(ideaToAdd);

		act.Should().Throw<ValidationException>();

        ideaRepositoryMock.Verify(r => r.Add(It.IsAny<IdeaEntity>()), Times.Never);
        ideaRepositoryMock.Verify(r => r.Save(), Times.Never);
    }

	[Fact]
	public void Add_GivenTheNameIsEmpty_ShouldThrowException()
	{
        var ideaRepositoryMock = new Mock<IIdeaRepository>();

        var ideaToAdd = CreateIdea(0, 15);
        var sut = new IdeaService(ideaRepositoryMock.Object);

		var act = () => sut.Add(ideaToAdd);

		act.Should().Throw<ValidationException>();

        ideaRepositoryMock.Verify(r => r.Add(It.IsAny<IdeaEntity>()), Times.Never);
        ideaRepositoryMock.Verify(r => r.Save(), Times.Never);
    }

	[Fact]
	public void Add_GivenDescriptionIsLessThen250Characters_ShouldAddIdea()
	{
        var ideaRepositoryMock = new Mock<IIdeaRepository>();

        var ideaToAdd = CreateIdea(15, 15);
        var ideaEntityToAdd = new IdeaEntity(2, ideaToAdd.Name, ideaToAdd.Description ?? string.Empty, DateTimeOffset.Now);
        var sut = new IdeaService(ideaRepositoryMock.Object);

        ideaRepositoryMock.Setup(r => r.Add(It.IsAny<IdeaEntity>())).Returns(ideaEntityToAdd);

        var result = sut.Add(ideaToAdd);

        result.Name.Should().Be(ideaToAdd.Name);
        result.Description.Should().Be(ideaToAdd.Description);
        result.Id.Should().Be(ideaEntityToAdd.Id);
        result.DateAdded.Should().Be(ideaEntityToAdd.DateAdded);

        ideaRepositoryMock.Verify(r => r.Add(It.IsAny<IdeaEntity>()), Times.Once);
        ideaRepositoryMock.Verify(r => r.Save(), Times.Once);
    }

	[Fact]
	public void Add_GivenDescriptionIsExactly250Characters_ShouldAddIdea()
	{
        var ideaRepositoryMock = new Mock<IIdeaRepository>();

        var ideaToAdd = CreateIdea(15, 250);
        var ideaEntityToAdd = new IdeaEntity(2, ideaToAdd.Name, ideaToAdd.Description ?? string.Empty, DateTimeOffset.Now);
        var sut = new IdeaService(ideaRepositoryMock.Object);

        ideaRepositoryMock.Setup(r => r.Add(It.IsAny<IdeaEntity>())).Returns(ideaEntityToAdd);

        var result = sut.Add(ideaToAdd);

        result.Name.Should().Be(ideaToAdd.Name);
        result.Description.Should().Be(ideaToAdd.Description);
        result.Id.Should().Be(ideaEntityToAdd.Id);
        result.DateAdded.Should().Be(ideaEntityToAdd.DateAdded);

        ideaRepositoryMock.Verify(r => r.Add(It.IsAny<IdeaEntity>()), Times.Once);
        ideaRepositoryMock.Verify(r => r.Save(), Times.Once);
    }

	[Fact]
	public void Add_GivenDescriptionIsLongerThen250Characters_ShouldThrowException()
	{
        var ideaRepositoryMock = new Mock<IIdeaRepository>();

        var ideaToAdd = CreateIdea(15, 251);
        var sut = new IdeaService(ideaRepositoryMock.Object);

		var act = () => sut.Add(ideaToAdd);

        act.Should().Throw<ValidationException>();

        ideaRepositoryMock.Verify(r => r.Add(It.IsAny<IdeaEntity>()), Times.Never);
        ideaRepositoryMock.Verify(r => r.Save(), Times.Never);
    }

	[Fact]
	public void Add_GivenDescriptionIsEmpty_ShouldAddIdea()
	{
        var ideaRepositoryMock = new Mock<IIdeaRepository>();

        var ideaToAdd = CreateIdea(15, 0);
        var ideaEntityToAdd = new IdeaEntity(2, ideaToAdd.Name, ideaToAdd.Description ?? string.Empty, DateTimeOffset.Now);
        var sut = new IdeaService(ideaRepositoryMock.Object);

        ideaRepositoryMock.Setup(r => r.Add(It.IsAny<IdeaEntity>())).Returns(ideaEntityToAdd);

        var result = sut.Add(ideaToAdd);

        result.Name.Should().Be(ideaToAdd.Name);
        result.Description.Should().Be(ideaToAdd.Description);
        result.Id.Should().Be(ideaEntityToAdd.Id);
        result.DateAdded.Should().Be(ideaEntityToAdd.DateAdded);

        ideaRepositoryMock.Verify(r => r.Add(It.IsAny<IdeaEntity>()), Times.Once);
        ideaRepositoryMock.Verify(r => r.Save(), Times.Once);
    }

	[Fact]
	public void Add_GivenIdeaIsSuccesfullyAdded_ShouldHaveIdAndDateAddedSet()
	{
        var ideaRepositoryMock = new Mock<IIdeaRepository>();

        var ideaToAdd = CreateIdea(15, 15);
        var ideaEntityToAdd = new IdeaEntity(2, ideaToAdd.Name, ideaToAdd.Description ?? string.Empty, DateTimeOffset.Now);
        var sut = new IdeaService(ideaRepositoryMock.Object);

        ideaRepositoryMock.Setup(r => r.Add(It.IsAny<IdeaEntity>())).Returns(ideaEntityToAdd);

        var result = sut.Add(ideaToAdd);

        result.Name.Should().Be(ideaToAdd.Name);
        result.Description.Should().Be(ideaToAdd.Description);
        result.Id.Should().Be(ideaEntityToAdd.Id);
        result.DateAdded.Should().Be(ideaEntityToAdd.DateAdded);

        ideaRepositoryMock.Verify(r => r.Add(It.IsAny<IdeaEntity>()), Times.Once);
        ideaRepositoryMock.Verify(r => r.Save(), Times.Once);
    }

	private Idea CreateIdea(int numOfCharactersName, int numOfCharachtersDescrption) =>
		new Idea(new string('a', numOfCharactersName), new string('a', numOfCharachtersDescrption));
}
