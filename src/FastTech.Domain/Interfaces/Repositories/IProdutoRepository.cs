using FastTech.Domain.Entities;

namespace FastTech.Domain.Interfaces.Repositories;

public interface IProdutoRepository
{
    Task<IEnumerable<Produto>> BuscarTodosAsync();
}
