using MediatR;

namespace FastTech.Application.NotificationErros;

public class NotificacaoErro : INotification
{
    public NotificacaoErro(string nomeProcesso, string mensagem)
    {
        NomeProcesso = nomeProcesso;
        Mensagem = mensagem;
    }
    
    public NotificacaoErro(string mensagem)
    {
        NomeProcesso = "Processo padrao";
    }

    public string NomeProcesso { get; set; }
    public string Mensagem { get; set; }
}