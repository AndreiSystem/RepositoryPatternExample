using Microsoft.EntityFrameworkCore;
using RepositoryPatternShow2.Commons.Context;
using RepositoryPatternShow2.Domain;
using System.Linq.Expressions;

namespace RepositoryPatternShow2.Commons.Repositories;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Base
{
    private readonly AppDbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;

    public BaseRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        TEntity entity = await _dbSet.FindAsync(id);

        if (entity is not null)
            _dbSet.Remove(entity);

        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task<IEnumerable<TEntity>> ObterAsync(Expression<Func<TEntity, bool>>? filter = null)
    {
        var query = _dbSet.AsQueryable();

        if (filter != null)
        {
            query = query
                .Where(filter)
                .AsNoTracking();
        }

        return await query.ToListAsync();
    }

    public virtual async Task<TEntity> ObterPorIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }
}
