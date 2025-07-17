using Api_restaurant.Classes;
using Api_restaurant.Data;
using Microsoft.EntityFrameworkCore;
using Api_restaurant.Dto;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RestaurantDb>(options =>
    options.UseSqlite("Data Source=restaurant.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


/*var app = builder.Build();

app.MapGet("/", () => "Hello World!");
*/
app.Run();
