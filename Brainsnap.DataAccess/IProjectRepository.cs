using Brainsnap.Domain;
using Brainsnap.Domain.Entities;

namespace Brainsnap.DataAccess;

public interface IProjectRepository
{
    ProjectEntity? Find(string name);
    ProjectEntity Add(Project project);
    bool Exists(string name);
    void Save();
}
