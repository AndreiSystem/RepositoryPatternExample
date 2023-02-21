using Microsoft.EntityFrameworkCore;
using RepositoryPatternShow2.Commons.Mappings;
using RepositoryPatternShow2.Domain;

namespace RepositoryPatternShow2.Commons.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMapping());
            modelBuilder.ApplyConfiguration(new ProdutoMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
