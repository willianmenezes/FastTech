using FastTech.Domain.Enums;

namespace FastTech.Domain.Entidades;

internal class Pedido : Entity
{
    public DateTime Cadastro { get; private set; }
    public decimal ValorTotal { get; private set; }
    public StatusPedido Status { get; private set; }

    private List<PedidoItem> _pedidoItems;
    public IReadOnlyCollection<PedidoItem> PedidoItens => _pedidoItems;

    public Pedido()
    {
        _pedidoItems = new List<PedidoItem>();
    }

    public void CalcularValorTotal()
    {
        ValorTotal = _pedidoItems.Sum(pedidoItem => pedidoItem.CalcularValor());
    }

    public void AdicionarItemNoPedido(PedidoItem pedidoItem)
    {
        if (ExistePedidoItem(pedidoItem)
            is var itemEncontrado && itemEncontrado != null)
        {
            itemEncontrado.AdicionarQuantidade(pedidoItem.Quantidade);
            pedidoItem = itemEncontrado;
        }
        else
        {
            _pedidoItems.Add(pedidoItem);
        }

        pedidoItem.CalcularValor();
        CalcularValorTotal();
    }

    public void RemoverItem(PedidoItem pedidoItem)
    {
        if (ExistePedidoItem(pedidoItem)
           is var itemEncontrado && itemEncontrado == null)
        {
            throw new Exception("O item nao foi encontrado no pedido. Item invalido.");
        }

        _pedidoItems.Remove(itemEncontrado);
        CalcularValorTotal();
    }

    private PedidoItem ExistePedidoItem(PedidoItem item)
    {
        return _pedidoItems.FirstOrDefault(pedidoItem => pedidoItem.ProdutoId == item.ProdutoId);
    }
}
