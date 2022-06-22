using FastTech.Application.NotificationErros;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FastTech.WEB.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected readonly IMediator Mediator;
        protected readonly NotificacaoErroHandler NotificationHandler;

        protected MainController(IMediator mediator, INotificationHandler<NotificacaoErro> notificationHandler)
        {
            Mediator = mediator;
            NotificationHandler = (NotificacaoErroHandler)notificationHandler;
        }

        protected bool ProcessoInvalido()
        {
            return NotificationHandler.ExisteErros();
        }

        protected IEnumerable<NotificacaoErro> ObterError()
        {
            return NotificationHandler.ObterErros();
        }
    }
}
