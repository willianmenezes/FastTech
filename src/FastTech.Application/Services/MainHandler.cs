using AutoMapper;
using FastTech.Application.NotificationErros;
using FluentValidation;
using MediatR;

namespace FastTech.Application.Services;

public abstract class MainHandler
{
    protected readonly IMediator Mediator;
    protected readonly IMapper Mapper;
    
    protected MainHandler(IMediator mediator, IMapper mapper)
    {
        Mediator = mediator;
        Mapper = mapper;
    }

    protected bool Validar<TEntity, TValidator>(TEntity entity, TValidator validator)
        where TEntity : class where TValidator : AbstractValidator<TEntity>
    {
        var validationResult = validator.Validate(entity);
        foreach (var error in validationResult.Errors)
        {
            Mediator.Publish(new NotificationError(entity.GetType().Name, error.ErrorMessage));
        }

        return validationResult.IsValid;
    }
}