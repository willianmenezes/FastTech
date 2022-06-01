using FastTech.Application.NotificationErros;
using FastTech.Application.Services.ProdutoHandler;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FastTech.WEB.Controllers;

[Route("api/[controller]")]
public class ProdutosController : MainController
{
    public ProdutosController(IMediator mediator, 
        INotificationHandler<NotificationError> notificationHandler) : base(mediator, notificationHandler)
    {
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarProduto([FromBody] CadastrarProdutoRequest request)
    {
        await Mediator.Send(request);

        if (ProcessoInvalido())
            return BadRequest(ObterError());
        
        return Ok();
    }
}
