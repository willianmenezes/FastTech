namespace FastTech.Domain.Common;

public abstract class Entity
{
    public Guid Id { get; private set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    protected abstract void Validar();
}
