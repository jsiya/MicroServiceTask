using Microsoft.EntityFrameworkCore;
using ProductQueryWebApi.Contexts;
using ProductQueryWebApi.Migrations;
using ProductQueryWebApi.Repositories.Abstracts;
using ProductQueryWebApi.Repositories.Concretes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IQueryRepository<Product>, QueryRepository>();

builder.Services.AddDbContext<AppDbContext>(
    option =>
    {
        option.UseSqlServer(builder.Configuration.GetConnectionString("default"));
    });

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.MapControllers();

app.Run();