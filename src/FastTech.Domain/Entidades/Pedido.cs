using FastTech.Domain.Enums;

namespace FastTech.Domain.Entidades;

internal class Pedido : Entity
{
    public DateTime Cadastro { get; private set; }
    public decimal ValorTotal { get; private set; }
    public StatusPedido Status { get; private set; }

    private List<PedidoItem> _pedidoItems;
    public IReadOnlyCollection<PedidoItem> PedidoItens => _pedidoItems;
}
