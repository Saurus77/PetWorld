using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PetWorld.Infrastructure.Data
{
    /// <summary>
    /// Fabryka DbContext używana w czasie projektowania (design-time) i migracji.
    /// Pozwala EF Core utworzyć PetWorldDbContext z poprawną konfiguracją.
    /// </summary>
    public class PetWorldDbContextFactory : IDesignTimeDbContextFactory<PetWorldDbContext>
    {
        /// <summary>
        /// Tworzy instancję PetWorldDbContext z ustawionymi opcjami połączenia do MySQL.
        /// </summary>
        /// <param name="args">Argumenty (niewykorzystywane)</param>
        /// <returns>Nowy kontekst bazy danych</returns>
        public PetWorldDbContext CreateDbContext(string[] args)
        {
            // Builder konfiguracji DbContext
            var optionsBuilder = new DbContextOptionsBuilder<PetWorldDbContext>();

            // Ustawienie połączenia do bazy MySQL
            optionsBuilder.UseMySql(
                "server=localhost;port=3306;database=petworld;user=root;password=password",
                new MySqlServerVersion(new Version(8, 0, 33)));

            // Zwrócenie nowego DbContext z ustawionymi opcjami
            return new PetWorldDbContext(optionsBuilder.Options);
        }
    }
}
