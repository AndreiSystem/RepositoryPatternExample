using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternShow2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RepositoryPatternShow2.Commons.Context;

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
