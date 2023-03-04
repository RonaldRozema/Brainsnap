using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Brainsnap.API.ViewModels;

public class AddProjectViewModel
{
	[JsonConstructor]
	public AddProjectViewModel(string name)
	{
		Name = name;
	}

	[Required]
	[MaxLength(50)]
	public string Name { get; init; }
}
