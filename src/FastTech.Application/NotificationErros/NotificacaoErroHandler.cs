using MediatR;

namespace FastTech.Application.NotificationErros;

public class NotificacaoErroHandler : INotificationHandler<NotificacaoErro>
{
    private readonly List<NotificacaoErro> _erros;

    public NotificacaoErroHandler()
    {
        _erros = new List<NotificacaoErro>();
    }

    public async Task Handle(NotificacaoErro notification, CancellationToken cancellationToken)
    {
        _erros.Add(notification);
        await Task.CompletedTask;
    }

    public IEnumerable<NotificacaoErro> ObterErros()
    {
        return _erros;
    }

    public bool ExisteErros()
    {
        return _erros.Any();
    }
}