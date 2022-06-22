using FastTech.Application.NotificationErros;

namespace FastTech.Application.DTOs;

public class BaseResponse
{
    public bool Status { get; private set; }
    public object? Resultado { get; private set; }
    public IEnumerable<NotificacaoErro>? Erros { get; private set; }

    public static BaseResponse Erro(IEnumerable<NotificacaoErro>? erros = null)
    {
        return new BaseResponse
        {
            Erros = erros,
            Status = false
        };
    }
    
    public static BaseResponse Sucesso(object? resultado = null)
    {
        return new BaseResponse
        {
            Resultado = resultado,
            Status = true
        };
    }
}