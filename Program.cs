using Microsoft.EntityFrameworkCore;
using Npgsql;
using TodoNET6;
using TodoNET6.db;
using TodoNET6.Models;
using TodoNET6.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionBuilder = new NpgsqlConnectionStringBuilder("")
{
    Host = "localhost",
    Port = 5432,
    Username = "postgres",
    Password = "password",
    Database = "todos_app"
};

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>(options => 
    options
        .UseNpgsql(connectionBuilder.ConnectionString)
        .UseSnakeCaseNamingConvention()
);

builder.Services.AddScoped<ITodoRepository, TodoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapRoutes();

app.Run();
