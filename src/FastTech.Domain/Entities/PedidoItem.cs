using FastTech.Domain.Common;

namespace FastTech.Domain.Entities;

internal class PedidoItem : Entity
{
    public Guid PedidoId { get; private set; }
    public Guid ProdutoId { get; private set; }
    public int Quantidade { get; private set; }
    public decimal ValorUnitario { get; private set; }
    public string? NomeProduto { get; private set; }
    public Pedido? Pedido { get; set; }

    public PedidoItem(Guid produtoId, int quantidade, decimal valorUnitario, string nomeProduto)
    {
        ProdutoId = produtoId;
        Quantidade = quantidade;
        ValorUnitario = valorUnitario;
        NomeProduto = nomeProduto;

        Validar();
    }

    public void VincularPedido(Guid pedidoId)
    {
        PedidoId = pedidoId;
    }

    public decimal CalcularValor()
    {
        return ValorUnitario * Quantidade;
    }

    public void AdicionarQuantidade(int quantidade)
    {
        Quantidade += quantidade;
    }

    public void AtualizarQuantidade(int quantidade)
    {
        Quantidade = quantidade;
    }

    protected override void Validar()
    {
        if (ProdutoId == Guid.Empty)
            throw new DomainException("Id do produto invalido.");

        if (Quantidade <= 0)
            throw new DomainException("Quantidade deve ser maior que 0.");  
        
        if (ValorUnitario <= 0)
            throw new DomainException("Valor deve ser maior que 0.");

        if (string.IsNullOrWhiteSpace(NomeProduto))
            throw new DomainException("Nome do produto invalido.");
    }
}