using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using TechStore.Data;

var builder = WebApplication.CreateBuilder(args);
Env.Load();

// Database connection

var host = Environment.GetEnvironmentVariable("DB_HOST");
var databaseName = Environment.GetEnvironmentVariable("DB_DATABASE");
var port = Environment.GetEnvironmentVariable("DB_PORT");
var username = Environment.GetEnvironmentVariable("DB_USERNAME");
var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

var connectionString = $"server={host};port={port};database={databaseName};uid={username};password={password}";

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.Parse("8.0.2-mysql")));


// Add services to the container.

builder.Services.AddControllers();
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
app.UseAuthorization();

// Basic welcome page with navigation to Swagger page
app.MapGet("/", () => Results.Content(@"
    <html>
        <head>
            <title>TechStore API</title>
        </head>
        <body style='font-family: Arial, sans-serif; background-color: #f4f4f4; text-align: center; height: 90%; display: flex; flex-direction: column; justify-content: center; align-items: center;'>
            <h1 style='color: #333; font-size: 36px;'>Welcome to TechStore API</h1>
            <a href='/swagger' style='color: #007bff; text-decoration: none;'> Click here to Swagger documentation</a>
        </body>
    </html>", "text/html"));

app.Run();
