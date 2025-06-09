namespace Medhelp.Contracts;

public record MedicineDto
{
    
    public required string Name { get; set; }
    
    public string? Description { get; set; }
    
    public int? LaunchYear { get; set; }
    
    public ICollection<string> ActiveSubstances { get; set; } = new List<string>();

    public ICollection<string> DrugActions { get; set; } = new List<string>();
    
    public ICollection<string> DrugForms { get; set; } = new List<string>();
    
    public ICollection<string> MedicalSpecialties { get; set; } = new List<string>();
    
    public ICollection<string> OrganSystems { get; set; } = new List<string>();
}