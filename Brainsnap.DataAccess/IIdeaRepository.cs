using Brainsnap.Domain.Entities;

namespace Brainsnap.DataAccess;

public interface IIdeaRepository
{
    IdeaEntity Add(IdeaEntity entityToAdd);
    void Delete(int id);
    int Save();
}
