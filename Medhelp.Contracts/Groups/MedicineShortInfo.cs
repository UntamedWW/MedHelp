namespace Medhelp.Contracts.Groups;

public record MedicineShortInfo
{
    public required Guid Id { get; set; }
    
    public required string Name { get; set; }

    public string? Description { get; set; }
}