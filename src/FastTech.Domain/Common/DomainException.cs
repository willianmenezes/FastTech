namespace FastTech.Domain.Common;

internal class DomainException : Exception
{
    public DomainException() { }

    public DomainException(string mensagem) : base(mensagem) { }

    public DomainException(string mensagem, Exception exception) : base(mensagem, exception) { }
}
