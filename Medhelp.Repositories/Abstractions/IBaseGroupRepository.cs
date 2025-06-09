using Medhelp.Domain.Entities;
using Medhelp.Domain.Models;

namespace Medhelp.Repositories.Abstractions;

public interface IBaseGroupRepository<TGroup> : IBaseRepository<TGroup>
    where TGroup : Group
{
    IQueryable<Medicine> GetAllMedicines(Guid id);

    Task<IEnumerable<TGroup>> FindAsync(string searchTerm);
}

