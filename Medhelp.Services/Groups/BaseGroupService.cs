using AutoMapper;
using Medhelp.Contracts.Groups;
using Medhelp.Domain.Models;
using Medhelp.Exceptions;
using Medhelp.Repositories.Abstractions;
using Medhelp.Services.Abstractions.Groups;
using Microsoft.EntityFrameworkCore;

namespace Medhelp.Services.Groups;

public abstract class BaseGroupService<TEntity, TModel> : IBaseGroupService<TModel>
    where TEntity : Group
    where TModel : GroupModel
{
    protected readonly IBaseGroupRepository<TEntity> Repository;
    protected readonly IMapper Mapper;

    protected BaseGroupService(IBaseGroupRepository<TEntity> repository, IMapper mapper)
    {
        Repository = repository;
        Mapper = mapper;
    }
    
    public async Task<TModel?> GetByIdAsync(Guid id)
    {
        return await Repository.FindByCondition(entity => entity.Id == id)
            .Select(entity => Mapper.Map<TModel>(entity))
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<TModel>> GetListAsync()
    {
        return await Repository.GetAll()
            .Select(entity => Mapper.Map<TModel>(entity))
            .ToListAsync();
    }

    public async Task<TModel> UpdateAsync(Guid id, GroupDto item)
    {
        var entity = await Repository.FindByConditionWithTracking(e => e.Id == id)
            .FirstOrDefaultAsync();

        if (entity is null)
        {
            throw new NotFoundException();
        }
        
        entity.Name = item.Name;
        await Repository.SaveChangesAsync();

        return Mapper.Map<TModel>(entity);
    }

    public async Task<TModel> AddAsync(GroupDto item)
    {
        var entity = Mapper.Map<TEntity>(item);
        
        entity = await Repository.AddAsync(entity);
        await Repository.SaveChangesAsync();

        return Mapper.Map<TModel>(entity);
    }

    public async Task<TModel?> DeleteAsync(Guid id)
    {
        var entity = await Repository.FindByConditionWithTracking(e => e.Id == id)
            .FirstOrDefaultAsync();

        if (entity is null)
        {
            return null;
        }
        
        await Repository.DeleteAsync(entity);
        await Repository.SaveChangesAsync();

        return Mapper.Map<TModel>(entity);
    }

    public async Task<IEnumerable<MedicineShortInfo>> GetMedicinesAsync(Guid id)
    {
        return await Repository.GetAllMedicines(id)
            .Select(medicine => new MedicineShortInfo
            {
                Id = medicine.Id,
                Name = medicine.Name,
                Description = medicine.Description
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<TModel>> FindAsync(string searchTerm)
    {
        return (await Repository.FindAsync(searchTerm))
            .Select(entity => Mapper.Map<TModel>(entity));
    }
}