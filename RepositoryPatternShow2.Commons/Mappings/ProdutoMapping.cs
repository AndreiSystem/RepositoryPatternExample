using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepositoryPatternShow2.Domain;

namespace RepositoryPatternShow2.Commons.Mappings;

public class ProdutoMapping : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable(nameof(Produto));

        builder.Property(x => x.Nome);

        builder.Property(x => x.Codigo);
    }
}
