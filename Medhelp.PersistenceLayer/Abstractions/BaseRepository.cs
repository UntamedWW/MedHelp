using System.Linq.Expressions;
using Medhelp.Domain.Models;
using Medhelp.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Medhelp.PersistenceLayer.Abstractions;

public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : Entity
{
    private readonly MedhelpContext _dbContext;
    private readonly DbSet<TEntity> _repositoryContext;

    protected BaseRepository(MedhelpContext dbContext)
    {
        _dbContext = dbContext;
        _repositoryContext = dbContext.Set<TEntity>();
    }

    public virtual IQueryable<TEntity> GetAll()
    {
        return _repositoryContext.AsNoTracking();
    }

    public virtual IQueryable<TEntity> FindByConditionWithTracking(
        Expression<Func<TEntity, bool>> expression
    )
    {
        return _repositoryContext.Where(expression);
    }

    public virtual IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
    {
        return _repositoryContext.Where(expression).AsNoTracking();
    }

    public virtual async Task<TEntity?> AddAsync(TEntity? entity)
    {
        if (entity is null)
        {
            return default;
        }

        if (await ExistsAsync(entity.Id))
        {
            return entity;
        }

        return (await _repositoryContext.AddAsync(entity)).Entity;
    }

    public virtual TEntity? Add(TEntity? entity)
    {
        if (entity is null)
        {
            return default;
        }

        return Exists(entity.Id) ? entity : _repositoryContext.Add(entity).Entity;
    }

    public virtual async Task UpdateAsync(TEntity? entity)
    {
        if (entity is null || !await ExistsAsync(entity.Id))
        {
            return;
        }

        _repositoryContext.Update(entity);
    }

    public virtual void Update(TEntity? entity)
    {
        if (entity is null || !Exists(entity.Id))
        {
            return;
        }

        _repositoryContext.Update(entity);
    }

    public virtual async Task DeleteAsync(TEntity? entity)
    {
        if (entity is null || !await ExistsAsync(entity.Id))
        {
            return;
        }

        _repositoryContext.Remove(entity);
    }

    public virtual void Delete(TEntity? entity)
    {
        if (entity is null || !Exists(entity.Id))
        {
            return;
        }

        _repositoryContext.Remove(entity);
    }

    public virtual Task<bool> ExistsAsync(Guid id)
    {
        return _repositoryContext.AnyAsync(record => Equals(record.Id, id));
    }

    public virtual Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        return _repositoryContext.AnyAsync(expression);
    }

    public virtual bool Exists(Guid id)
    {
        return _repositoryContext.Any(record => Equals(record.Id, id));
    }

    public virtual async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public virtual int SaveChanges()
    {
        return _dbContext.SaveChanges();
    }
}
