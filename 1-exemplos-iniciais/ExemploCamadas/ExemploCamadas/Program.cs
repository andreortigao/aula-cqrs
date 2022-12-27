using System.Reflection;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ExemploCamadas.Apresentacao.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ExemploCamadasApresentacaoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ExemploCamadasApresentacaoContext") ?? throw new InvalidOperationException("Connection string 'ExemploCamadasApresentacaoContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly());

var connString = builder.Configuration.GetConnectionString("Database");

//builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Clientes}/{action=Index}/{id?}");

app.Run();
