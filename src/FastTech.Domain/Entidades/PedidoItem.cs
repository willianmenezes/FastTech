namespace FastTech.Domain.Entidades;

internal class PedidoItem : Entity
{
    public Guid PedidoId { get; set; }
    public int Quantidade { get; private set; }
    public decimal ValorUnitario { get; private set; }
    public string NomeProduto { get; private set; }

    public Pedido Pedido { get; set; }
}