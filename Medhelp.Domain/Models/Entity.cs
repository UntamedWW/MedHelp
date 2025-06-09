namespace Medhelp.Domain.Models;

/// <summary>
/// Bazowa klasa dla wszystkich encji w systemie
/// </summary>
public abstract class Entity
{
    /// <summary>
    /// Unikalny identyfikator encji
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Data utworzenia encji
    /// </summary>
    public DateTime CreatedAt { get; set; }
}
