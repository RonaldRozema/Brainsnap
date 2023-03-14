namespace Brainsnap.Domain.Entities;

public class IdeaEntity
{
	public IdeaEntity(int id, string name, string description, DateTimeOffset dateAdded)
	{
		Id = id;
		Name = name;
		Description = description;
		DateAdded = dateAdded;
	}

	public int Id { get; }
	public string Name { get; }
	public string Description { get; }
	public DateTimeOffset DateAdded { get; }

	public Idea ToIdea() => new Idea(Id, Name, Description, DateAdded);
}

