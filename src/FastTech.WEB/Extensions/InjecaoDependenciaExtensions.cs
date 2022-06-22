using FastTech.Application.DTOs;
using FastTech.Application.Mappings;
using FastTech.Application.NotificationErros;
using FastTech.Application.Services.ProdutoHandler;
using FastTech.Domain.Interfaces.Repositories;
using FastTech.Infrastructure.Context;
using FastTech.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FastTech.WEB.Extensions;

public static class InjecaoDependenciaExtensions
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        // condigurar provider banco de dados
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("FastTechConnection"),
                x => x.MigrationsHistoryTable("Historico_Migracoes_EF")));

        // Configurando Mediatr
        services.AddMediatR(typeof(Program));
        services.AddScoped<IRequestHandler<CadastrarProdutoRequest, BaseResponse>, ProdutoRequestHandler>();

        // notificacoes erro
        services.AddScoped<INotificationHandler<NotificacaoErro>, NotificacaoErroHandler>();

        // repositorios
        services.AddScoped<IProdutoRepository, ProdutoRepository>();

        // automapper
        services.AddAutoMapper(typeof(ProdutoProfile));
    }

    public static void UseFastTechErrorHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<FastTechErrorHandler>();
    }
}