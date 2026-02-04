using PetWorld.Domain.Entities;
using PetWorld.Domain.Repositories;
using PetWorld.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace PetWorld.Infrastructure.Repositories
{
    /// <summary>
    /// Repozytorium produktów.
    /// Implementuje IProductRepository przy użyciu Entity Framework Core.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly PetWorldDbContext _context;

        /// <summary>
        /// Konstruktor repozytorium przyjmujący DbContext.
        /// </summary>
        /// <param name="context">Kontekst bazy danych</param>
        public ProductRepository(PetWorldDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Pobiera wszystkie produkty z bazy danych.
        /// </summary>
        /// <returns>Lista wszystkich produktów</returns>
        public async Task<IReadOnlyList<Product>> GetAllAsync() =>
            await _context.Products.ToListAsync();


        /// <summary>
        /// Pobiera produkt po jego identyfikatorze.
        /// </summary>
        /// <param name="id">Id produktu</param>
        /// <returns>Produkt lub null, jeśli nie istnieje</returns>
        public async Task<Product?> GetByIdAsync(Guid id) =>
            await _context.Products.FindAsync(id);

        /// <summary>
        /// Dodaje nowy produkt do bazy danych.
        /// </summary>
        /// <param name="product">Produkt do dodania</param>
        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);     // Dodanie do DbSet
            await _context.SaveChangesAsync();  // Zapis zmian w bazie
        }
    }
}
