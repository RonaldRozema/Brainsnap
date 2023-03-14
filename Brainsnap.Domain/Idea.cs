using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Brainsnap.Domain.Entities;

namespace Brainsnap.Domain;

public class Idea
{
	[JsonConstructor]
	public Idea(string name, string? description)
	{
		Name = name;
		Description = description;
		Id = null;
		DateAdded = null;
	}

	public Idea(int id, string name, string description, DateTimeOffset dateAdded)
	{
		Id = id;
		Name = name;
		Description = description;
		DateAdded = dateAdded;
	}

	public int? Id { get; init; }
	public string Name { get; init; }
	public string? Description { get; init; }
	public DateTimeOffset? DateAdded { get; private set; }

	public void Validate()
	{
		if (string.IsNullOrEmpty(Name)) throw new ValidationException("Idea name can't be empty");
		if (Name.Length > 50) throw new ValidationException("Idea name can't be longer then 50 characters");
		if (Description?.Length > 250) throw new ValidationException("Idea description can't be longer then 250 characters");
	}

	public IdeaEntity ToEntity() => new IdeaEntity(Id ?? 0, Name, Description ?? string.Empty, DateAdded ?? DateTimeOffset.Now);
}
