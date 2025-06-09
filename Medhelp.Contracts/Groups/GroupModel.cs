namespace Medhelp.Contracts.Groups;

public record GroupModel
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}