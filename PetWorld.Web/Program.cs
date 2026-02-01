using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PetWorld.Web.Data;
using Microsoft.EntityFrameworkCore;
using PetWorld.Application.Agents;
using PetWorld.Application.Orchestration;
using PetWorld.Application.Services;
using PetWorld.Infrastructure.Data;
using PetWorld.Infrastructure.Repositories;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using PetWorld.Domain.Repositories;


var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<PetWorldDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 33))));

// Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IChatHistoryRepository, ChatHistoryRepository>();

// Application Services
builder.Services.AddScoped<WriterCriticOrchestrator>();
builder.Services.AddScoped<IChatService, ChatService>();

// AI Agents
//builder.Services.AddScoped<IWriterAgent, WriterAgent>();
//builder.Services.AddScoped<ICriticAgent, CriticAgent>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
