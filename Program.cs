using System;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

using mcdonalds_api.Model;
using mcdonalds_api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//poder ser Singleton, Transient e Scoped
builder.Services.AddScoped<McDataBaseContext>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>(); //quando vc pedir o IOrderRepository ele da o OrderRepository 

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

//Singleton: é criada uma única instância para todas requisições. Em outras palavras, é criada uma instância a primeira vez que é solicitada e 
//todas as vezes seguintes a mesma instância é usada (design patter singleton);

//Transient:  sempre é criada uma nova instância cada vez que for necessário, independentede da requisição, basicamente new XXX cada vez que for 
//necessário.

//Scoped: é criada uma única instância por requição. Ou seja, usando o exemplo de uma aplicação Web, quando recebe uma nova requisição, por 
//exemplo, um click num botão do outro lado do navegador, é criada uma instância, onde o escopo é essa requisição. Então se for necessária a 
//dependência multiplas vezes na mesma requisição a mesma instância será usada. Seria como um "Singleton para uma requisição";

//                             Tipo	             Mesma requisição	      Requisições diferentes
//                             Singleton	     Mesma instância	      Mesma instância
//                             Scoped	         Mesma instância	      Nova instância
//                             Transient	     Nova instância	          Nova instância