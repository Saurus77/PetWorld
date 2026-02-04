using Microsoft.EntityFrameworkCore;
using PetWorld.Domain.Entities;
using PetWorld.Infrastructure.Data;

namespace PetWorld.Infrastructure
{
    /// <summary>
    /// Klasa pomocnicza do wstępnego zapełnienia bazy danych produktami.
    /// </summary>
    public static class DbInitializer
    {
        /// <summary>
        /// Tworzy bazę danych jeśli nie istnieje i dodaje przykładowe produkty.
        /// </summary>
        /// <param name="context">Kontekst bazy danych</param>
        public static async Task InitializeAsync(PetWorldDbContext context)
        {
            // Utworzenie bazy danych jeśli nie istnieje
            await context.Database.EnsureCreatedAsync();

            // Jeśli tabela Products nie jest pusta, nie dodajemy produktów
            if (await context.Products.AnyAsync()) return;

            // Lista przykładowych produktów
            var products = new List<Product>
            {
                new Product("Royal Canin Adult Dog 15kg", "Premium karma dla dorosłych psów średnich ras", "Karma dla psów", 289),
                new Product("Whiskas Adult Kurczak 7kg", "Sucha karma dla dorosłych kotów z kurczakiem", "Karma dla kotów", 129),
                new Product("Tetra AquaSafe 500ml", "Uzdatniacz wody do akwarium, neutralizuje chlor", "Akwarystyka", 45),
                new Product("Trixie Drapak XL 150cm", "Wysoki drapak z platformami i domkiem", "Akcesoria dla kotów", 399),
                new Product("Kong Classic Large", "Wytrzymała zabawka do napełniania smakołykami", "Zabawki dla psów", 69),
                new Product("Ferplast Klatka dla chomika", "Klatka 60x40cm z wyposażeniem", "Gryzonie", 189),
                new Product("Flexi Smycz automatyczna 8m", "Smycz zwijana dla psów do 50kg", "Akcesoria dla psów", 119),
                new Product("Brit Premium Kitten 8kg", "Karma dla kociąt do 12 miesiąca życia", "Karma dla kotów", 159),
                new Product("JBL ProFlora CO2 Set", "Kompletny zestaw CO2 dla roślin akwariowych", "Akwarystyka", 549),
                new Product("Vitapol Siano dla królików 1kg", "Naturalne siano łąkowe, podstawa diety", "Gryzonie", 25)
            };

            // Dodanie produktów do kontekstu bazy
            await context.Products.AddRangeAsync(products);

            // Zapisanie zmian w bazie danych
            await context.SaveChangesAsync();
        }
    }
}
