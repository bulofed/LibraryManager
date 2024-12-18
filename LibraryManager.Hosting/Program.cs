using DataAccessLayer.Contexts;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, 
    "..",
    "..",
    "..",
    "..",
    "DataAccessLayer", 
    "Ressources", 
    "library.db");

builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlite($"Data Source={databasePath}"));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

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