using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("Settings")]
public class Settings
{

    [Required, Key]
    public string Id { get; set; } = string.Empty;
    [Required]
    public string Value { get; set; } = string.Empty;
 

}

