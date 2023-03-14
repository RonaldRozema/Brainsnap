using Brainsnap.DataAccess;
using Brainsnap.Domain;

namespace Brainsnap.Services;

public class IdeaService : IIdeaService
{
    private readonly IIdeaRepository _ideaRepository;

	public IdeaService(IIdeaRepository ideaRepository)
	{
        _ideaRepository = ideaRepository;
	}

    public Idea Create(Idea ideaToAdd)
    {
        ideaToAdd.Validate();
        var entity = _ideaRepository.Add(ideaToAdd.ToEntity()).ToIdea();
        _ideaRepository.Save();
        return entity;
    }
}

