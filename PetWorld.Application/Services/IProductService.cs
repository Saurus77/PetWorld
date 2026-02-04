using PetWorld.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetWorld.Application.Services
{
    public interface IProductService
    {
        Task<IReadOnlyList<Product>> GetAllProductsAsync();
    }
}
