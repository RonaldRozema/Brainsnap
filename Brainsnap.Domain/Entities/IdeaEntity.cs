using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Brainsnap.Domain.Entities;

public class IdeaEntity
{
	public IdeaEntity(int id)
	{
		Id = id;
		Name = string.Empty;
		Description = string.Empty;
		DateAdded = DateTimeOffset.Now;
	}

	[JsonConstructor]
	public IdeaEntity(int id, string name, string description, DateTimeOffset dateAdded)
	{
		Id = id;
		Name = name;
		Description = description;
		DateAdded = dateAdded;
	}

	public int Id { get; init; }
	[MaxLength(50)]
	public string Name { get; init; }
	[MaxLength(250)]
	public string Description { get; init; }
	public DateTimeOffset DateAdded { get; init; }

	public Idea ToIdea() => new Idea(Id, Name, Description, DateAdded);
}

