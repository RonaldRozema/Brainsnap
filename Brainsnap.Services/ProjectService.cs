using System.ComponentModel.DataAnnotations;
using Brainsnap.DataAccess;
using Brainsnap.Domain;
using Brainsnap.Domain.Exceptions;

namespace Brainsnap.Services;

public class ProjectService : IProjectService
{
    public readonly IProjectRepository _projectRepo;

	public ProjectService(IProjectRepository projectRepo)
	{
        _projectRepo = projectRepo;
	}

    public Project Create(string name)
    {
        if (name.Length > 50) throw new ValidationException("Project name is over 50 characters");
        if (_projectRepo.Exists(name)) return Find(name);
        var newProject = _projectRepo.Add(new Project(name)).ToModel();
        _projectRepo.Save();
        return newProject;
    }

    public Project Find(string name) =>
        _projectRepo.Find(name)?.ToModel() ?? throw new NotFoundException($"No {name} project found.");
}
