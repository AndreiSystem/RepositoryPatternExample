﻿using RepositoryPatternShow2.Domain;
using System.Linq.Expressions;

namespace RepositoryPatternShow2.Commons.Repositories;

public interface IBaseRepository<TEntity> where TEntity : Base
{
    Task AddAsync(TEntity entity);
    Task<IEnumerable<TEntity>> ObterAsync(Expression<Func<TEntity, bool>>? filter = null);
    Task<TEntity> ObterPorIdAsync(Guid id);
    Task DeleteAsync(Guid id);
}
