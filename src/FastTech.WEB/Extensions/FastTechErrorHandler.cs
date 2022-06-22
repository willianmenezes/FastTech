using System.Net;
using System.Text.Json;
using FastTech.Application.DTOs;
using FastTech.Application.NotificationErros;
using FastTech.Domain.DomainObjects;

namespace FastTech.WEB.Extensions;

public class FastTechErrorHandler
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public FastTechErrorHandler(RequestDelegate next, ILoggerFactory logger)
    {
        _next = next;
        _logger = logger.CreateLogger("FastTech error Handler");
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandlerErrorAsync(httpContext, ex);
        }
    }

    private async Task HandlerErrorAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        BaseResponse baseResponse;
        NotificacaoErro notificacaoErro;
        HttpStatusCode statusCode;

        switch (ex)
        {
            case DomainException:
                notificacaoErro = new NotificacaoErro(ex.Message, "Validacao de Dominio.");
                statusCode = HttpStatusCode.BadRequest;
                break;
            case ArgumentException or ArgumentNullException:
                notificacaoErro = new NotificacaoErro(ex.Message, "Argumentos invalidos.");
                statusCode = HttpStatusCode.BadRequest;
                break;
            default:
                notificacaoErro = new NotificacaoErro("Erro de servidor", "Erro generico.");
                statusCode = HttpStatusCode.InternalServerError;
                break;
        }
        
        FormatarErro();
        _logger.LogError($"Erro: {ex.Message}");
        _logger.LogError($"Stack: {ex.StackTrace}");

        await context.Response.WriteAsync(JsonSerializer.Serialize(baseResponse));

        void FormatarErro()
        {
            context.Response.StatusCode = (int)statusCode;
            baseResponse = BaseResponse.Erro(new List<NotificacaoErro>()
            {
                notificacaoErro
            });
        }
    }
}