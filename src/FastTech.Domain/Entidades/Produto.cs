using FastTech.Domain.Enums;

namespace FastTech.Domain.Entidades;

internal class Produto : Entity
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
    }

    public string Nome { get; private set; }
    public string Descricao { get; private set; }
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
            throw new Exception("Nome invalido.");

        Nome = novoNome;
    }

    public void AlterarDescricao(string novaDescricao)
    {
        if (string.IsNullOrWhiteSpace(novaDescricao))
            throw new Exception("Descricao invalida.");

        Descricao = novaDescricao;
    }

    public void DebitarEstoque(int quantidade)
    {
        if (quantidade < 0)
            throw new Exception("Quantidade invalida.");

        if (!PossuiEstoque(quantidade))
        {
            throw new Exception("Quantidade em estoque insuficiente");
        }

        QuantidadeEstoque -= quantidade;
    }

    public bool PossuiEstoque(int quantidade) => QuantidadeEstoque >= quantidade;

    public void AdicionarEstoque(int quantidade)
    {
        QuantidadeEstoque += quantidade;
    }
}