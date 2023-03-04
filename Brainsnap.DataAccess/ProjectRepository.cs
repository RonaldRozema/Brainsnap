using Brainsnap.DataAccess.EfContexts;
using Brainsnap.Domain;
using Brainsnap.Domain.Entities;

namespace Brainsnap.DataAccess;

public class ProjectRepository : IProjectRepository
{
    private readonly PsqlDbContext _context;

	public ProjectRepository(PsqlDbContext context)
	{
        _context = context;
	}

    public ProjectEntity Add(Project project)
    {
        var entity = project.ToEntity();
        _context.Add(entity);
        return entity;
    }

    public ProjectEntity? Find(string name) =>
        _context.Projects.FirstOrDefault(p => p.Name == name);

    public bool Exists(string name) =>
        _context.Projects.Any(p => p.Name == name);

    public void Save() =>
        _context.SaveChanges();
}

