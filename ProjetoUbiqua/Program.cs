using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjetoUbiqua.Autenticação.JWT.JWTLogic;
using ProjetoUbiqua.Autenticação.JWT.JWTLogic.Interface;
using ProjetoUbiqua.Context;
using ProjetoUbiqua.EntitiesManagers;
using ProjetoUbiqua.EntitiesManagers.Interfaces;
using System.Text;

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
builder.Services.AddScoped<IJWTService, JWTService>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration.GetValue<string>("JWT:ValidAudience"),
        ValidIssuer = builder.Configuration.GetValue<string>("JWT:ValidIssuer"),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("JWT:Secret")))
    };
});


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
