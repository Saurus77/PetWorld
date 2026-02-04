using Microsoft.EntityFrameworkCore;
using PetWorld.Application.Agents;
using PetWorld.Application.Orchestration;
using PetWorld.Application.Services;
using PetWorld.Domain.Repositories;
using PetWorld.Infrastructure;
using PetWorld.Infrastructure.Agents;
using PetWorld.Infrastructure.Data;
using PetWorld.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Pobranie klucza API OpenAI z systemowej zmiennej œrodowiskowej
var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY")
             ?? throw new InvalidOperationException("OPENAI_API_KEY environment variable is not set.");


// ----------------------
// Konfiguracja bazy danych + DI
// ----------------------
builder.Services.AddDbContext<PetWorldDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                     new MySqlServerVersion(new Version(8, 0, 33)),
                     mySqlOptions => mySqlOptions.EnableRetryOnFailure(
                         maxRetryCount: 5,
                         maxRetryDelay: TimeSpan.FromSeconds(10),
                         errorNumbersToAdd: null))
    );

// ----------------------
// Rejestracja repozytoriów i serwisów w DI
// ----------------------
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IChatHistoryRepository, ChatHistoryRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IChatHistoryService, ChatHistoryService>();
builder.Services.AddScoped<IWriterAgent, WriterAgent>();
builder.Services.AddScoped<ICriticAgent, CriticAgent>();
builder.Services.AddScoped<WriterCriticOrchestrator>();
builder.Services.AddScoped<IChatService, ChatService>();


// ----------------------
// Rejestracja Blazor
// ----------------------
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// ----------------------
// Budowa aplikacji
// ----------------------
var app = builder.Build();


// ----------------------
// Inicjalizacja bazy danych z produktami
// ----------------------
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PetWorldDbContext>();
    await DbInitializer.InitializeAsync(context);
}

// ----------------------
// Mapowanie endpointów Blazor
// ----------------------
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");


// ----------------------
// Uruchomienie aplikacji
// ----------------------
app.Run();
