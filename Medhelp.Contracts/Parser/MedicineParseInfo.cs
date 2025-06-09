namespace Medhelp.Contracts.Parser;

public record MedicineParseInfo
{
    public required string Name { get; set; }
    
    public required Uri DetailsUrl { get; set; }
}