using System.Linq.Expressions;
using Medhelp.Domain.Models;

namespace Medhelp.Repositories.Abstractions;

public interface IBaseRepository<TEntity> where TEntity : Entity
{
    IQueryable<TEntity> GetAll();
    
    IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression);
    
    IQueryable<TEntity> FindByConditionWithTracking(Expression<Func<TEntity, bool>> expression);
    
    Task<TEntity?> AddAsync(TEntity entity);
    
    TEntity? Add(TEntity entity);

    Task UpdateAsync(TEntity? entity);
    
    void Update(TEntity entity);

    Task DeleteAsync(TEntity? entity);
    
    void Delete(TEntity entity);

    Task<bool> ExistsAsync(Guid id);

    bool Exists(Guid id);
    
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression);

    Task<int> SaveChangesAsync();
    
    int SaveChanges();
}