using AutoMapper;
using FastTech.Domain.Entities;
using FastTech.Domain.Interfaces.Repositories;
using MediatR;

namespace FastTech.Application.Services.ProdutoHandler;

public class ProdutoRequestHandler : MainHandler, IRequestHandler<CadastrarProdutoRequest, bool>
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoRequestHandler(IProdutoRepository produtoRepository, IMediator mediator, IMapper mapper) :
        base(mediator, mapper)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<bool> Handle(CadastrarProdutoRequest request, CancellationToken cancellationToken)
    {
        var result = Validar(request, new CadastrarProdutoRequestValidator());
        if (!result) return false;

        var produto = Mapper.Map<Produto>(request);

        await _produtoRepository.Adicionar(produto);
        await _produtoRepository.UnityOfWork.Commit();
        return true;
    }
}