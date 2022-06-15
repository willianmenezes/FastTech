using FastTech.Application.Mappings;
using FastTech.Application.NotificationErros;
using FastTech.Application.Services.ProdutoHandler;
using FastTech.Domain.Interfaces.Repositories;
using FastTech.Infrastructure.Context;
using FastTech.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// condigurar provider banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("FastTechConnection"),
    x => x.MigrationsHistoryTable("Historico_Migracoes_EF")));

// Configurando Mediatr
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddScoped<IRequestHandler<CadastrarProdutoRequest, bool>, ProdutoRequestHandler>();

// notificacoes erro
builder.Services.AddScoped<INotificationHandler<NotificationError>, NotificationErrorHandler>();

// repositorios
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

// automapper
builder.Services.AddAutoMapper(typeof(ProdutoProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
