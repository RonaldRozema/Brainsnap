using Brainsnap.Domain;

namespace Brainsnap.Services;

public interface IIdeaService
{
    Idea Create(Idea ideaToAdd);
    bool Delete(int id);
}

