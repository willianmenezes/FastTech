﻿using FastTech.Domain.Entities;
using FastTech.Domain.Interfaces.Repositories;
using FastTech.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FastTech.Infrastructure.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

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
}
