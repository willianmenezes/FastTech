namespace FastTech.Domain.Entidades;

internal class PedidoItem : Entity
{
    public Guid PedidoId { get; private set; }
    public Guid ProdutoId { get; private set; }
    public int Quantidade { get; private set; }
    public decimal ValorUnitario { get; private set; }
    public string NomeProduto { get; private set; }

    public Pedido Pedido { get; set; }

    public decimal CalcularValor()
    {
        return ValorUnitario * Quantidade;
    }

    public void AdicionarQuantidade(int quantidade)
    {
        Quantidade += quantidade;
    }
}