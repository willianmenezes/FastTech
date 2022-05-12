using FastTech.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FastTech.WEB.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : MainController
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutosController(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    [HttpGet]
    public async Task<IActionResult> BuscarProdutos()
    {
        return Ok(await _produtoRepository.BuscarTodosAsync());
    }
}
