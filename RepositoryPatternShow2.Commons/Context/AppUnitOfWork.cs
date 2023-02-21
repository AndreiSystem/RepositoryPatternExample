namespace RepositoryPatternShow2.Commons.Context;

public class AppUnitOfWork : ContextDatabase<AppDbContext>
{
	public AppUnitOfWork(AppDbContext dbContext) : base(dbContext)
	{
	} 
}
