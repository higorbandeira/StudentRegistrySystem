using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<StudentRegistryContext>(x =>
{
    x.UseNpgsql(connectionString, options =>
    {
        options.MigrationsAssembly("Infra.Data");
    });

    x.EnableSensitiveDataLogging(); // Apenas para desenvolvimento
    x.EnableDetailedErrors(); // Apenas para desenvolvimento
    x.LogTo(Console.WriteLine, LogLevel.Information); // Log das queries
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<StudentRegistryContext>();
dbContext.Database.Migrate();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
