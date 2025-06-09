using Medhelp.Contracts.Groups;

namespace Medhelp.Contracts;

public record MedicineModel
{
    public required string Name { get; set; }
    
    public string? Description { get; set; }

    public int? LaunchYear { get; set; }

    public IEnumerable<ActiveSubstanceModel> ActiveSubstances { get; set; } = new List<ActiveSubstanceModel>();

    public IEnumerable<DrugActionModel> DrugActions { get; set; } = new List<DrugActionModel>();
    
    public IEnumerable<DrugFormModel> DrugForms { get; set; } = new List<DrugFormModel>();
    
    public IEnumerable<MedicalSpecialtyModel> MedicalSpecialties { get; set; } = new List<MedicalSpecialtyModel>();
    
    public IEnumerable<OrganSystemModel> OrganSystems { get; set; } = new List<OrganSystemModel>();
}
