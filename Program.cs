var builder = WebApplication.CreateBuilder(args);

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
