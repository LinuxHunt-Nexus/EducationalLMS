using System.Linq.Expressions;

namespace LearningManagement.Application.Repository;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<List<TEntity>> GetByCondition(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter);
}