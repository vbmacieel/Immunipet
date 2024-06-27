using Immunipet.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Immunipet.API.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Pet> Pets { get; set; }
}