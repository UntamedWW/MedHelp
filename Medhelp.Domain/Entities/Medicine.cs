using System.ComponentModel.DataAnnotations;
using Medhelp.Domain.Models;

namespace Medhelp.Domain.Entities;

/// <summary>
/// Reprezentuje lek lub preparat medyczny
/// </summary>
public class Medicine : Entity
{
    /// <summary>
    /// Nazwa leku
    /// </summary>
    [Required]
    [MaxLength(200)]
    public required string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Wskazania do stosowania leku
    /// </summary>
    public string? Description { get; set; } = string.Empty;

    /// <summary>
    /// Rok wprowadzenia leku na rynek
    /// </summary>
    public int? LaunchYear { get; set; }

    /// <summary>
    /// Substancje czynne zawarte w leku
    /// </summary>
    public ICollection<ActiveSubstance> ActiveSubstances { get; set; } = new List<ActiveSubstance>();

    /// <summary>
    /// Działania leku
    /// </summary>
    public ICollection<DrugAction> DrugActions { get; set; } = new List<DrugAction>();
    
    /// <summary>
    /// Dostępne formy leku
    /// </summary>
    public ICollection<DrugForm> DrugForms { get; set; } = new List<DrugForm>();
    
    /// <summary>
    /// Specjalności medyczne powiązane z lekiem
    /// </summary>
    public ICollection<MedicalSpecialty> MedicalSpecialties { get; set; } = new List<MedicalSpecialty>();
    
    /// <summary>
    /// Układy narządowe, na które działa lek
    /// </summary>
    public ICollection<OrganSystem> OrganSystems { get; set; } = new List<OrganSystem>();
    
    /// <summary>
    /// Reprezentuje grupę chorób/dolegliwości
    /// </summary>
    public ICollection<DiseaseGroup> DiseaseGroups { get; set; } = new List<DiseaseGroup>();
}
