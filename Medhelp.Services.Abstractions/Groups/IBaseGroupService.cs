using Medhelp.Contracts.Groups;

namespace Medhelp.Services.Abstractions.Groups;

public interface IBaseGroupService<TModel>
    where TModel : GroupModel
{
    Task<TModel?> GetByIdAsync(Guid id);

    Task<IEnumerable<TModel>> GetListAsync();

    Task<TModel> UpdateAsync(Guid id, GroupDto item);

    Task<TModel> AddAsync(GroupDto item);

    Task<TModel?> DeleteAsync(Guid id);

    Task<IEnumerable<MedicineShortInfo>> GetMedicinesAsync(Guid id);

    Task<IEnumerable<TModel>> FindAsync(string searchTerm);
}