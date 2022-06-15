namespace FastTech.Domain.Interfaces;

public interface IUnityOfWork
{
    Task Commit();
}