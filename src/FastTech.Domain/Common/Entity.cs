namespace FastTech.Domain.Common;

internal abstract class Entity
{
    public Guid Id { get; private set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    protected abstract void Validar();
}
