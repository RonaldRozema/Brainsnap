using Brainsnap.Domain.Entities;

namespace Brainsnap.Domain;

public class Project
{
	public Project(string name)
	{
		Name = name;
		DateAdded = DateTimeOffset.Now;
	}

	public Project(string name, DateTimeOffset dateAdded)
	{
		Name = name;
		DateAdded = dateAdded;
	}

	public string Name { get; init; }
	public DateTimeOffset DateAdded { get; init; }

	public ProjectEntity ToEntity() =>
		new ProjectEntity(Name, DateAdded);
}
