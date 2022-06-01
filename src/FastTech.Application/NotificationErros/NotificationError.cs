using MediatR;

namespace FastTech.Application.NotificationErros;

public class NotificationError : INotification
{
    public NotificationError(string nomeProcesso, string mensagem)
    {
        NomeProcesso = nomeProcesso;
        Mensagem = mensagem;
    }
    
    public NotificationError(string mensagem)
    {
        NomeProcesso = "Processo padrao";
    }

    public string NomeProcesso { get; set; }
    public string Mensagem { get; set; }
}