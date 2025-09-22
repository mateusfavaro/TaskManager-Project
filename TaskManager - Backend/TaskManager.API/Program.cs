using Microsoft.EntityFrameworkCore;
using TaskManager.API.Filters;
using TaskManager.Application.UseCases;
using TaskManager.Infrastructure;
using TaskManager.Infrastructure.DataAcess.Repositories;

var builder = WebApplication.CreateBuilder(args);

var allowedOrigin = "http://localhost:8080";

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins(allowedOrigin)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add services to the container.

builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddHttpClient();

builder.Services.AddDbContext<TasksDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),sqlOptions => sqlOptions.MigrationsAssembly("TaskManager.Infrastructure")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(o => o.Filters.Add(typeof(ExceptionFilter)));

builder.Services.AddRouting(option => option.LowercaseUrls = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
