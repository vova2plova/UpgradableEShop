using CatalogService.Application.Behaviours;
using CatalogService.Application.Items.CreateItem;
using CatalogService.Application.Mediator;
using MediatR;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var assemblies = Assembly.Load("CatalogService.Application");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

    config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
});

builder.Services.AddSingleton<IValidator<CreateItemCommand>, CreateItemCommandValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
