namespace RepositoryPatternShow2.Domain;

public class Cliente : Base
{
    public string? Nome { get; set; }
    public string? Email { get; set; }

    public Cliente(Guid id, string? nome, string? email) : base(id)
    {
        Nome = nome;
        Email = email;
    }
}