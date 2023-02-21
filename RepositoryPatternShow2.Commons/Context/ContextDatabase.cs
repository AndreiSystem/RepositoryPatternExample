using Microsoft.EntityFrameworkCore;
using static System.GC;

namespace RepositoryPatternShow2.Commons.Context;

public abstract class ContextDatabase<TDbContext> : IContextDatabase, IDisposable where TDbContext : DbContext
{
    private readonly TDbContext _dbContext;
    private Guid? _controlScope;

    protected ContextDatabase(TDbContext dbContext)
    {
        _dbContext = dbContext;
        _controlScope = null;
    }

    public async Task<bool> CommitAsync(Guid? controlScope)
    {
        if (!IsClassControlScope(controlScope))
            return true;

        var commitSucess = await _dbContext.SaveChangesAsync().ConfigureAwait(false) > 0;

        if (commitSucess)
        {
            _controlScope = null;
        }

        return commitSucess;
    }

    private bool IsClassControlScope(Guid? controlScope)
    {
        var result = _controlScope is null || _controlScope == controlScope;

        return result;
    }

    public virtual void Dispose(bool disposing)
    {
        if (!disposing) return;
        _dbContext.Dispose();
    }

    public void Dispose()
    {
        Dispose(true);
        SuppressFinalize(this);
    }
}
