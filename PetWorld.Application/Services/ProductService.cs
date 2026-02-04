using PetWorld.Domain.Entities;
using PetWorld.Domain.Repositories;

namespace PetWorld.Application.Services
{
    /// <summary>
    /// Serwis odpowiedzialny za udostępnianie produktów.
    /// Implementuje <see cref="IProductService"/>.
    /// </summary>
    public class ProductService : IProductService
    {
        // Repozytorium produktów, umożliwia pobieranie danych z bazy
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Konstruktor wstrzykujący repozytorium produktów.
        /// </summary>
        /// <param name="productRepository">Repozytorium produktów</param>
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Pobiera wszystkie produkty dostępne w systemie.
        /// </summary>
        /// <returns>Lista produktów jako IReadOnlyList&lt;Product&gt;</returns>
        public async Task<IReadOnlyList<Product>> GetAllProductsAsync()
        {
            // Delegacja pobrania produktów do repozytorium
            return await _productRepository.GetAllAsync();
        }
    }
}
