using Brainsnap.DataAccess.EfContexts;
using Brainsnap.Domain.Entities;

namespace Brainsnap.DataAccess;

public class IdeaRepository : IIdeaRepository
{
    private readonly PsqlDbContext _context;

	public IdeaRepository(PsqlDbContext context)
	{
        _context = context;
	}

    public IdeaEntity Add(IdeaEntity entityToAdd)
    {
        _context.Add(entityToAdd);
        return entityToAdd;
    }

    public void Save() => _context.SaveChanges();
}
