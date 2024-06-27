using Immunipet.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Immunipet.API.Endpoints;

public static class PetEndpointsExt
{
    public static void MapPetEndpoints(this WebApplication app)
    {
        app.MapGet("/pets", async (AppDbContext db) => Results.Ok(await db.Pets.ToListAsync()));

        app.MapGet("/pet/{id}", async (AppDbContext db, int id) =>
        {
            var pet = await db.Pets.FindAsync(id);
            return pet is not null ? Results.Ok(pet) : Results.NotFound();
        });

        app.MapPost("/pet", async (AppDbContext db) =>
        {

        });
    }
}