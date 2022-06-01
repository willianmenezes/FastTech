using FastTech.Application.NotificationErros;
using FastTech.Domain.Entities;
using FastTech.Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;

namespace FastTech.Application.Services.ProdutoHandler;

public class ProdutoRequestHandler : IRequestHandler<CadastrarProdutoRequest, bool>
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IMediator _mediator;

    public ProdutoRequestHandler(IProdutoRepository produtoRepository, IMediator mediator)
    {
        _produtoRepository = produtoRepository;
        _mediator = mediator;
    }

    public async Task<bool> Handle(CadastrarProdutoRequest request, CancellationToken cancellationToken)
    {
        var result = Validar(request, new CadastrarProdutoRequestValidator());
        if (!result) return false;

        var produto = new Produto(request.Nome, request.Descricao, request.Valor, request.Tipo,
            request.QuantidadeEstoque);

        await _produtoRepository.Adicionar(produto);
        return true;
    }

    private bool Validar<TEntity, TValidator>(TEntity entity, TValidator validator)
        where TEntity : class where TValidator : AbstractValidator<TEntity>
    {
        var validationResult = validator.Validate(entity);
        foreach (var error in validationResult.Errors)
        {
            _mediator.Publish(new NotificationError(entity.GetType().Name, error.ErrorMessage));
        }

        return validationResult.IsValid;
    }
}