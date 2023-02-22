using RepositoryPatternShow2.Commons.Context;
using RepositoryPatternShow2.Domain;

namespace RepositoryPatternShow2.Commons.Repositories;

public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
{
    public ProdutoRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
