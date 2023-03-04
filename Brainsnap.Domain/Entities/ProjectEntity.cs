using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Brainsnap.Domain.Entities;

public class ProjectEntity
{
    [JsonConstructor]
	public ProjectEntity(string name, DateTimeOffset dateAdded)
	{
		Name = name;
		DateAdded = dateAdded;
	}

	[MaxLength(50)]
	public string Name { get; set; }
	public DateTimeOffset DateAdded { get; set; }

	public Project ToModel() =>
		new Project(Name, DateAdded);
}

