using BooksStore.Data;
using BooksStore.Services;
using Microsoft.EntityFrameworkCore;
using BooksStore.Middleware;
using Scalar.AspNetCore;
using DotNetEnv;
using static DotNetEnv.Env;

var builder = WebApplication.CreateBuilder(args);


var projectRoot = Directory.GetCurrentDirectory();
var envFile = Path.Combine(projectRoot, ".env");

if (File.Exists(envFile))
{
    Env.Load(envFile);
}



builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);
builder.Services.AddScoped<GetBooksService>();
builder.Services.AddScoped<AddWriterService>();

builder.Services.AddAutoMapper(cfg => { }, typeof(Program));

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
