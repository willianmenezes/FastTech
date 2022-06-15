using FastTech.Domain.Entities;

namespace FastTech.Domain.Interfaces.Repositories;

public interface IProdutoRepository
{
    IUnityOfWork UnityOfWork { get; }
    Task<IEnumerable<Produto>> BuscarTodosAsync();
    Task Adicionar(Produto produto);
}