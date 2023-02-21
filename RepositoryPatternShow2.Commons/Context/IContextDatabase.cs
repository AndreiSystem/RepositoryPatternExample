namespace RepositoryPatternShow2.Commons.Context;

public interface IContextDatabase
{
    Task<bool> CommitAsync(Guid? controlScope);
}
