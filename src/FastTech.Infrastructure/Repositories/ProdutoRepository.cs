using FastTech.Domain.Entities;
using FastTech.Domain.Interfaces;
using FastTech.Domain.Interfaces.Repositories;
using FastTech.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FastTech.Infrastructure.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    public IUnityOfWork UnityOfWork => _applicationDbContext;

    public ProdutoRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<IEnumerable<Produto>> BuscarTodosAsync()
    {
        return await _applicationDbContext.Produtos
            .Where(x => x.Ativo == true)
            .ToListAsync();
    }

    public async Task Adicionar(Produto produto)
    {
        await _applicationDbContext.Produtos.AddAsync(produto);
    }
}