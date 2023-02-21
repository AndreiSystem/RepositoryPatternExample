using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepositoryPatternShow2.Domain;

namespace RepositoryPatternShow2.Commons.Mappings;

public class ClienteMapping : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder) 
    {
        builder.ToTable(nameof(Cliente));

        builder.Property(x => x.Nome);

        builder.Property(x => x.Email);
    }
}
