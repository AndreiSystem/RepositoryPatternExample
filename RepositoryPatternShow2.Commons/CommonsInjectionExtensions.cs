using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RepositoryPatternShow2.Commons.Context;
using RepositoryPatternShow2.Commons.Repositories;

namespace RepositoryPatternShow2.Commons;

public static class CommonsInjectionExtensions
{
    public static void AddCommons(this IServiceCollection services)
    {
        services.AddPostgres<AppDbContext, AppUnitOfWork>();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
    }

    private static void AddPostgres<TDbContext, TUnitOfWork>(this IServiceCollection services,
        Action<DbContextOptionsBuilder> action = null) where TDbContext : DbContext
        where TUnitOfWork : class, IContextDatabase
    {
        services.AddDbContextPool<TDbContext>(optionsBuilder =>
        {
            optionsBuilder.UseNpgsql("Host=localhost;Username=repository-name;Password=repository-password;Port=5432;Database=repository-database");
        });

        services.AddScoped<IContextDatabase, TUnitOfWork>();

        CreateDatabase(services);
    }

    private static void CreateDatabase(IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        using var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var scopedServices = serviceScope.ServiceProvider;

        var dbContext = scopedServices.GetRequiredService<AppDbContext>();

        dbContext.Database.Migrate();
    }
}
