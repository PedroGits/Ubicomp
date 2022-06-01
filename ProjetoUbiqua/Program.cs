using Microsoft.EntityFrameworkCore;
using ProjetoUbiqua.Context;
using ProjetoUbiqua.EntitiesManagers;
using ProjetoUbiqua.EntitiesManagers.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("UbiquaDbConnection");
    options.UseSqlServer(connectionString);
});

//Dependencias
builder.Services.AddScoped<ISalaManager, SalaManager>();
builder.Services.AddScoped<ISensorManager, SensorManager>();
builder.Services.AddScoped<IUtilizadorManager, UtilizadorManager>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
