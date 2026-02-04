using PetWorld.Domain.Entities;

namespace PetWorld.Application.Services
{
    /// <summary>
    /// Interfejs definiujący kontrakt dla serwisu produktów.
    /// Każda implementacja powinna umożliwiać pobranie listy wszystkich produktów w systemie.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Pobiera wszystkie produkty dostępne w systemie.
        /// </summary>
        /// <returns>Lista produktów jako IReadOnlyList&lt;Product&gt;</returns>
        Task<IReadOnlyList<Product>> GetAllProductsAsync();
    }
}
