using FastTech.Domain.Common;
using FastTech.Domain.Enums;

namespace FastTech.Domain.Entities;

public class Pedido : Entity
{
    public DateTime Cadastro { get; private set; }
    public decimal ValorTotal { get; private set; }
    public StatusPedido Status { get; private set; }

    private List<PedidoItem> _pedidoItems;
    public IReadOnlyCollection<PedidoItem> PedidoItens => _pedidoItems;

    public Pedido()
    {
        _pedidoItems = new List<PedidoItem>();
        Cadastro = DateTime.UtcNow;
        Status = StatusPedido.Novo;
    }

    public void CalcularValorTotal()
    {
        ValorTotal = _pedidoItems.Sum(pedidoItem => pedidoItem.CalcularValor());
    }

    public void AdicionarItemNoPedido(PedidoItem pedidoItem)
    {
        pedidoItem.VincularPedido(Id);

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
            throw new DomainException("O item nao foi encontrado no pedido. Item invalido.");
        }

        _pedidoItems.Remove(itemEncontrado);
        CalcularValorTotal();
    }

    public void AtualizarQuantidadeItem(PedidoItem item, int novaQuantidade)
    {
        if (ExistePedidoItem(item)
           is var itemEncontrado && itemEncontrado == null)
        {
            throw new DomainException("O item nao foi encontrado no pedido. Item invalido.");
        }

        itemEncontrado.AtualizarQuantidade(novaQuantidade);
        CalcularValorTotal();
    }

    public void AguardarPagamento()
    {
        Status = StatusPedido.AguardandoPagamento;
    }

    public void ConcluirPedido()
    {
        Status = StatusPedido.Concluido;
    }

    private PedidoItem ExistePedidoItem(PedidoItem item)
    {
        return _pedidoItems.FirstOrDefault(pedidoItem => pedidoItem.ProdutoId == item.ProdutoId);
    }

    protected override void Validar()
    {
        if (Cadastro.Date <= DateTime.UtcNow.Date)
            throw new DomainException("Data de cadastro invalida.");

        if (Cadastro.Date <= DateTime.UtcNow.Date)
            throw new DomainException("Data de cadastro invalida.");
    }
}
