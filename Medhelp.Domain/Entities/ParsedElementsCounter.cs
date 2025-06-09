using System.Diagnostics.CodeAnalysis;
using Medhelp.Domain.Models;

namespace Medhelp.Domain.Entities;

/// <summary>
/// Przechowuje informacje o postępie parsowania elementów z określonego źródła.
/// </summary>
public class ParsedElementsCounter : Entity
{
    /// <summary>
    /// Nazwa źródła, z którego pochodzą parsowane elementy.
    /// </summary>
    public required string SourceName { get; set; }
    
    /// <summary>
    /// Numer ostatniej przetworzonej strony.
    /// </summary>
    public int LastPage { get; set; } = 1;

    /// <summary>
    /// Numer ostatniego przetworzonego elementu na stronie.
    /// </summary>
    public int LastElementNumber { get; set; } = 0;

    /// <summary>
    /// Określa, czy parsowanie elementów zostało zakończone.
    /// </summary>
    public bool IsEnded { get; set; } = false;

    [SetsRequiredMembers]
    public ParsedElementsCounter(string sourceName)
    {
        SourceName = sourceName;
    }
    
    public ParsedElementsCounter()
    {
        
    }

    public void GoToNextPage()
    {
        LastPage++;
        LastElementNumber = 0;
    }
}

