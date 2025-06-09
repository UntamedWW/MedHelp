using System.ComponentModel.DataAnnotations;
using Medhelp.Domain.Entities;

namespace Medhelp.Domain.Models;

public abstract class Group : Entity
{
    /// <summary>
    /// Nazwa substancji aktywnej
    /// </summary>
    [Required]
    [MaxLength(200)]
    public required string Name { get; set; }

    public ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();
}