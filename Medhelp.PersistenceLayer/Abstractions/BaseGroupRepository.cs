using Medhelp.Domain.Entities;
using Medhelp.Domain.Models;
using Medhelp.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Medhelp.PersistenceLayer.Abstractions;

public abstract class BaseGroupRepository<TGroup>(MedhelpContext dbContext)
    : BaseRepository<TGroup>(dbContext), IBaseGroupRepository<TGroup>
    where TGroup : Group
{
    public IQueryable<Medicine> GetAllMedicines(Guid id)
    {
        return FindByCondition(group => group.Id == id)
            .Include(group => group.Medicines)
            .SelectMany(group => group.Medicines);
    }

    public async Task<IEnumerable<TGroup>> FindAsync(string searchTerm)
    {
        return await FindByCondition(group => group.Name.Contains(searchTerm))
            .ToListAsync();
    }
}