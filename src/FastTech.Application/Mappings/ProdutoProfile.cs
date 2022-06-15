using AutoMapper;
using FastTech.Application.Services.ProdutoHandler;
using FastTech.Domain.Entities;

namespace FastTech.Application.Mappings;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<CadastrarProdutoRequest, Produto>().ConstructUsing(request =>
            new Produto(request.Nome, request.Descricao, request.Valor, request.Tipo, request.QuantidadeEstoque));
    }
}