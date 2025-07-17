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
            Name = "Loïc, Abdellah , Othman, Nicolas",
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


// GET tous les clients
app.MapGet("/clients", async (RestaurantDb db) =>
{
    var clients = await db.Clients.ToListAsync();
    return Results.Ok(clients);
});

// GET client par ID
app.MapGet("/clients/{id}", async (int id, RestaurantDb db) =>
{
    var client = await db.Clients.FindAsync(id);
    return client is not null ? Results.Ok(client) : Results.NotFound();
});

// POST ajouter un client
app.MapPost("/clients", async (Client client, RestaurantDb db) =>
{
    db.Clients.Add(client);
    await db.SaveChangesAsync();
    return Results.Created($"/clients/{client.Id}", client);
});

// PUT modifier un client
app.MapPut("/clients/{id}", async (int id, Client updatedClient, RestaurantDb db) =>
{
    var client = await db.Clients.FindAsync(id);
    if (client is null) return Results.NotFound();

    client.Nom = updatedClient.Nom;
    client.Prenom = updatedClient.Prenom;
    client.NumeroDeRue = updatedClient.NumeroDeRue;
    client.NomDeRue = updatedClient.NomDeRue;
    client.CodePostal = updatedClient.CodePostal;
    client.Ville = updatedClient.Ville;
    client.Telephone = updatedClient.Telephone;

    await db.SaveChangesAsync();
    return Results.Ok(client);
});

// DELETE supprimer un client
app.MapDelete("/clients/{id}", async (int id, RestaurantDb db) =>
{
    var client = await db.Clients.FindAsync(id);
    if (client is null) return Results.NotFound();

    db.Clients.Remove(client);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

DbInitializer.Database(app.Services);

app.Run();

