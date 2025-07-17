using Api_restaurant.Classes;
using Api_restaurant.Data;
using Api_restaurant.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RestaurantDb>(opt => opt.UseSqlite("Data Source=restaurant.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Restaurant API",
        Version = "v1",
        Description = "Une API pour gérer les commandes d'un restaurant",
        Contact = new OpenApiContact
        {
            Name = "Loïc, Abdellag , Othman, Nicolas",
            Email = "nephtyse19@hotmail.fr",
            Url = new Uri("https://github.com/abdellah59/Api-restaurant")
        }
    });
    // Activer les annotations swagger
    c.EnableAnnotations();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant API V1");
        c.RoutePrefix = "";
    });
}
app.Run();

