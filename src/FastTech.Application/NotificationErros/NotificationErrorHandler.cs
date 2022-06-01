using MediatR;

namespace FastTech.Application.NotificationErros;

public class NotificationErrorHandler : INotificationHandler<NotificationError>
{
    private readonly List<NotificationError> _erros;

    public NotificationErrorHandler()
    {
        _erros = new List<NotificationError>();
    }

    public async Task Handle(NotificationError notification, CancellationToken cancellationToken)
    {
        _erros.Add(notification);
        await Task.CompletedTask;
    }

    public IEnumerable<NotificationError> ObterErros()
    {
        return _erros;
    }

    public bool ExisteErros()
    {
        return _erros.Any();
    }
}