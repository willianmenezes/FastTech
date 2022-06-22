using FastTech.Application.DTOs;
using FastTech.Domain.Enums;
using MediatR;

namespace FastTech.Application.Services.ProdutoHandler;

public class CadastrarProdutoRequest : IRequest<BaseResponse>
{
    public CadastrarProdutoRequest(string? nome, string? descricao, decimal valor, TipoProduto tipo, int quantidadeEstoque)
    {
        Nome = nome;
        Descricao = descricao;
        Valor = valor;
        Tipo = tipo;
        QuantidadeEstoque = quantidadeEstoque;
    }

    public string? Nome { get; private set; }
    public string? Descricao { get; private set; }
    public decimal Valor { get; private set; }
    public TipoProduto Tipo { get; private set; }
    public int QuantidadeEstoque { get; private set; }
}