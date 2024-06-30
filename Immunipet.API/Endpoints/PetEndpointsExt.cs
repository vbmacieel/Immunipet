using AutoMapper;
using Immunipet.API.Data;
using Immunipet.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Immunipet.API.Endpoints;

public static class PetEndpointsExt
{
    public static void MapPetEndpoints(this WebApplication app)
    {
        var mapper = app.Services.GetService<IMapper>();

        app.MapGet("/pets", async (AppDbContext db) => Results.Ok(await db.Pets.ToListAsync()));

        app.MapGet("/pet/{id}", async (AppDbContext db, int id) =>
        {
            var pet = await db.Pets.FindAsync(id);
            return pet is not null ? Results.Ok(pet) : Results.NotFound();
        });

        app.MapPost("/pet", async (AppDbContext db, Pet pet) =>
        {
            db.Pets.Add(pet);
            await db.SaveChangesAsync();

            return Results.Created($"/pet/{pet.Id}", pet);
        });

        app.MapPut("/pet/{id}", async (AppDbContext db, int id, Pet pet) => 
        {
            var findPet = await db.Pets.FindAsync(id);

            if (findPet is null) return Results.NotFound();

            pet.Name = findPet.Name;
            pet.Birthday = findPet.Birthday;
            pet.Age = findPet.Age;

            await db.SaveChangesAsync();
            return Results.NoContent();
        }); 

        app.MapDelete("/pet/{id}", async (AppDbContext db, int id) => 
        {
            if (await db.Pets.FindAsync(id) is Pet pet)
            {
                db.Pets.Remove(pet);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }

            return Results.NotFound();
        });
    }
}