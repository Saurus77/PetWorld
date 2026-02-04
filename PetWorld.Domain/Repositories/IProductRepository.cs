using PetWorld.Domain.Entities;

namespace PetWorld.Domain.Repositories
{
    /// <summary>
    /// Interfejs definiujący kontrakt repozytorium produktów.
    /// Znajduje się w warstwie Domain, aby zachować separację zależności.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Pobiera wszystkie produkty dostępne w systemie.
        /// </summary>
        /// <returns>Lista produktów jako IReadOnlyList<Product></returns>
        Task<IReadOnlyList<Product>> GetAllAsync();

        /// <summary>
        /// Pobiera produkt po jego unikalnym identyfikatorze.
        /// </summary>
        /// <param name="id">Id produktu</param>
        /// <returns>Produkt lub null, jeśli nie istnieje</returns>
        Task<Product?> GetByIdAsync(Guid id);

        /// <summary>
        /// Dodaje nowy produkt do repozytorium.
        /// </summary>
        /// <param name="product">Produkt do dodania</param>
        /// <returns>Task reprezentujący operację asynchroniczną</returns>
        Task AddAsync(Product product);
    }
}
