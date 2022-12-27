using ExemploCqrs.Aplicacao.Geral;
using ExemploCqrs.Aplicacao.Recursos.Pedidos.ListarPedidos;
using ExemploCqrs.BancoDados;
using ExemploCqrs.Behaviors;
using ExemploCqrs.Middlewares;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var applicationAsm = typeof(ListarPedidosQuery).Assembly;
builder.Services.AddMediatR(applicationAsm);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidatorBehavior<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
builder.Services.AddValidatorsFromAssembly(applicationAsm);

builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly());

var connString = builder.Configuration.GetConnectionString("Database");

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connString));
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection(nameof(SmtpSettings)));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
