namespace RepositoryPatternShow2.Domain;

public class Produto : Base
{
    public string? Nome { get; set; }
    public int Codigo { get; set; }
    public Produto(Guid id, string? nome, int codigo) : base(id)
    {
        Nome = nome;
        Codigo = codigo;
    }
}
