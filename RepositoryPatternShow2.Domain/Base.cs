namespace RepositoryPatternShow2.Domain;

public abstract class Base
{
    public Guid Id { get; set; }
	public Base(Guid id)
	{
		Id = id;
	}
}
