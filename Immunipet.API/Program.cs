using Immunipet.API.Data;
using Immunipet.API.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opts => 
    opts.UseInMemoryDatabase("ImmunipetDb"));

builder.Services.AddAuthentication();
builder.Services.AddAuthentication().AddBearerToken();

var app = builder.Build();

app.MapPetEndpoints();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.Run();
