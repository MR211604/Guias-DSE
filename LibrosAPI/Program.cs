using JwtAuthenticationManager;
using LibrosAPI.Data;
using LibrosAPI.Models;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<LibrosDbContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Servicio para testing inMemory
builder.Services.AddDbContext<LibrosDbContext>(options => 
    options.UseInMemoryDatabase("LibrosInMemoryDb"));


//CONFIG DE REDIS
builder.Services.AddStackExchangeRedisOutputCache(options =>
{
    options.Configuration =
   builder.Configuration.GetConnectionString("RedisConnection");
});
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    var configuration =
   ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("RedisConnection")!, true);
    return ConnectionMultiplexer.Connect(configuration);
});
builder.Services.AddOutputCache();



builder.Services.AddCustomJwtAuthentication();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseOutputCache(); // <- NUEVO 

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
