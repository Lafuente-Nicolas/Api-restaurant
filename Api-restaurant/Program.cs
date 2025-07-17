using Api_restaurant.Classes;
using Api_restaurant.Data;
using Api_restaurant.Dto;
using Api_restaurant.DTO;
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

// ? ENDPOINTS POUR LA GESTION DES COMMANDES

// GET : Récupère toutes les commandes
app.MapGet("/api/commandes", async (RestaurantDb db) =>
{
    var commandes = await db.Commandes
        .Include(c => c.clients)
        .Include(c => c.Articles)
        .ToListAsync();

    var result = commandes.Select(c => new CommandeItemDTO(c));
    return Results.Ok(result);
})
.WithName("GetAllCommandes")
.WithTags("Commandes")
.WithMetadata(new SwaggerOperationAttribute(summary: "Récupère toutes les commandes", description: "Retourne la liste complète des commandes"));

// GET : Récupère une commande par ID
app.MapGet("/api/commandes/{id}", async (int id, RestaurantDb db) =>
{
    var commande = await db.Commandes
        .Include(c => c.clients)
        .Include(c => c.Articles)
        .FirstOrDefaultAsync(c => c.Id == id);

    if (commande is null) return Results.NotFound();
    return Results.Ok(new CommandeItemDTO(commande));
})
.WithName("GetCommandeById")
.WithTags("Commandes")
.WithMetadata(new SwaggerOperationAttribute(summary: "Récupère une commande par ID", description: "Retourne une commande spécifique"));

// POST : Crée une nouvelle commande
app.MapPost("/api/commandes", async (CommandeItemDTO dto, RestaurantDb db) =>
{
    var commande = new Commande
    {
        clients = dto.clients,
        Articles = dto.Articles,
        DateCommande = dto.DateCommande
    };

    db.Commandes.Add(commande);
    await db.SaveChangesAsync();

    return Results.Created($"/api/commandes/{commande.Id}", new CommandeItemDTO(commande));
})
.WithName("CreateCommande")
.WithTags("Commandes")
.WithMetadata(new SwaggerOperationAttribute(summary: "Crée une nouvelle commande", description: "Ajoute une commande dans la base de données"));

// PUT : Met à jour une commande existante
app.MapPut("/api/commandes/{id}", async (int id, CommandeItemDTO dto, RestaurantDb db) =>
{
    var commande = await db.Commandes.Include(c => c.clients).Include(c => c.Articles).FirstOrDefaultAsync(c => c.Id == id);
    if (commande is null) return Results.NotFound();

    commande.clients = dto.clients;
    commande.Articles = dto.Articles;
    commande.DateCommande = dto.DateCommande;

    await db.SaveChangesAsync();
    return Results.NoContent();
})
.WithName("UpdateCommande")
.WithTags("Commandes")
.WithMetadata(new SwaggerOperationAttribute(summary: "Met à jour une commande", description: "Modifie une commande existante"));

// DELETE : Supprime une commande
app.MapDelete("/api/commandes/{id}", async (int id, RestaurantDb db) =>
{
    var commande = await db.Commandes.FindAsync(id);
    if (commande is null) return Results.NotFound();

    db.Commandes.Remove(commande);
    await db.SaveChangesAsync();

    return Results.NoContent();
})
.WithName("DeleteCommande")
.WithTags("Commandes")
.WithMetadata(new SwaggerOperationAttribute(summary: "Supprime une commande", description: "Supprime une commande par ID"));

DbInitializer.Database(app.Services);


app.Run();

