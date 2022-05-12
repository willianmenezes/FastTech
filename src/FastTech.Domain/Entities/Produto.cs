using FastTech.Domain.Common;
using FastTech.Domain.Enums;

namespace FastTech.Domain.Entities;

public class Produto : Entity
{
    public Produto(string nome, string descricao, decimal valor,
        TipoProduto tipo, int quantidadeEstoque)
    {
        Nome = nome;
        Descricao = descricao;
        Ativo = true;
        Valor = valor;
        Cadastro = DateTime.UtcNow;
        Tipo = tipo;
        QuantidadeEstoque = quantidadeEstoque;

        Validar();
    }

    public string? Nome { get; private set; }
    public string? Descricao { get; private set; }
    public bool Ativo { get; private set; }
    public decimal Valor { get; private set; }
    public DateTime Cadastro { get; private set; }
    public TipoProduto Tipo { get; private set; }
    public int QuantidadeEstoque { get; private set; }

    public void Ativar() => Ativo = true;

    public void Desativar() => Ativo = false;

    public void AlterarTipo(TipoProduto novoTipo) => Tipo = novoTipo;

    public void AlterarNome(string novoNome)
    {
        if (string.IsNullOrWhiteSpace(novoNome))
            throw new DomainException("Nome invalido.");

        Nome = novoNome;
    }

    public void AlterarDescricao(string novaDescricao)
    {
        if (string.IsNullOrWhiteSpace(novaDescricao))
            throw new DomainException("Descricao invalida.");

        Descricao = novaDescricao;
    }

    public void DebitarEstoque(int quantidade)
    {
        if (quantidade < 0)
            throw new DomainException("Quantidade invalida.");

        if (!PossuiEstoque(quantidade))
        {
            throw new DomainException("Quantidade em estoque insuficiente");
        }

        QuantidadeEstoque -= quantidade;
    }

    public bool PossuiEstoque(int quantidade) => QuantidadeEstoque >= quantidade;

    public void AdicionarEstoque(int quantidade)
    {
        QuantidadeEstoque += quantidade;
    }

    protected override void Validar()
    {
        if (string.IsNullOrWhiteSpace(Nome))
            throw new DomainException("O nome nao pode estar vazio.");

        if (string.IsNullOrWhiteSpace(Descricao))
            throw new DomainException("A descricao nao pode estar vazia.");

        if (Valor <= 0)
            throw new DomainException("O valor nao pode ser menor ou igual a 0."); 
        
        if (Cadastro.Date < DateTime.UtcNow.Date)
            throw new DomainException("O produto nao pode ser cadastrado em uma data retroativa.");
        
        if (QuantidadeEstoque < 0)
            throw new DomainException("Quantidade invalida.");
    }
}