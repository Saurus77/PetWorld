using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetWorld.Domain.Entities;

namespace PetWorld.Domain.Repositories
{
    // Interfejs repozytorium produktów
    public interface IProductRepository
    {
        // Pobiera produkty, zwracając je jako listę tylko do odczytu asynchronicznie
        Task<IReadOnlyList<Product>> GetAllAsync();
    }
}
