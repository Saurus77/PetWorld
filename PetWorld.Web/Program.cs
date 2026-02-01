using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using PetWorld.Application.Agents;
using PetWorld.Application.Orchestration;
using PetWorld.Application.Services;
using PetWorld.Infrastructure.Agents;
using PetWorld.Infrastructure.Data;
using PetWorld.Infrastructure.Repositories;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using PetWorld.Domain.Repositories;
using OpenAI;
using PetWorld.Infrastructure.Configuration;


var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<PetWorldDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 33)),
        mySqlOptions => mySqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(10),
            errorNumbersToAdd: null
        )
    )
);

// Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IChatHistoryRepository, ChatHistoryRepository>();

// Application Services
builder.Services.AddScoped<WriterCriticOrchestrator>();
builder.Services.AddScoped<IChatService, ChatService>();

// AI Agents
builder.Services.AddScoped<IWriterAgent, WriterAgent>();
builder.Services.AddScoped<ICriticAgent, CriticAgent>();

// AI API/Model Key
builder.Services.Configure<OpenAISettings>(builder.Configuration.GetSection("OpenAI"));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();





var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PetWorldDbContext>();

    var maxAttempts = 5;
    for (int i = 1; i <= maxAttempts; i++)
    {
        try
        {
            db.Database.Migrate(); // ensure tables exist
            DbInitializer.DbSeed(db); // seed products
            break;
        }
        catch (MySqlConnector.MySqlException)
        {
            Console.WriteLine($"Attempt {i}/{maxAttempts} - MySQL not ready yet, retrying...");
            await Task.Delay(5000); // wait 5s before retry
        }
    }
}

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
