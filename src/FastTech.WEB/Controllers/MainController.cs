using FastTech.Application.NotificationErros;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FastTech.WEB.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected readonly IMediator Mediator;
        protected readonly NotificationErrorHandler NotificationHandler;

        protected MainController(IMediator mediator, INotificationHandler<NotificationError> notificationHandler)
        {
            Mediator = mediator;
            NotificationHandler = (NotificationErrorHandler)notificationHandler;
        }

        protected bool ProcessoInvalido()
        {
            return NotificationHandler.ExisteErros();
        }

        protected IEnumerable<NotificationError> ObterError()
        {
            return NotificationHandler.ObterErros();
        }
    }
}
