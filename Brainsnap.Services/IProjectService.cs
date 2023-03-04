using Brainsnap.Domain;

namespace Brainsnap.Services;

public interface IProjectService
{
	Project Find(string name);
	Project Create(string name);
}
