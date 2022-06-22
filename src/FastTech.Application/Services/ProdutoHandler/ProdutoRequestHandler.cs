using AutoMapper;
using FastTech.Application.DTOs;
using FastTech.Domain.Entities;
using FastTech.Domain.Interfaces.Repositories;
using MediatR;

namespace FastTech.Application.Services.ProdutoHandler;

public class ProdutoRequestHandler : MainHandler, IRequestHandler<CadastrarProdutoRequest, BaseResponse>
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoRequestHandler(IProdutoRepository produtoRepository, IMediator mediator, IMapper mapper) :
        base(mediator, mapper)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<BaseResponse> Handle(CadastrarProdutoRequest request, CancellationToken cancellationToken)
    {
        var result = Validar(request, new CadastrarProdutoRequestValidator());
        if (!result) return BaseResponse.Erro();

        var produto = Mapper.Map<Produto>(request);

        await _produtoRepository.Adicionar(produto);
        await _produtoRepository.UnityOfWork.Commit();
        return BaseResponse.Sucesso();
    }
}