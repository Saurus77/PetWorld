using PetWorld.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetWorld.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IReadOnlyList<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(Guid id);
        Task AddAsync(Product product);
    }
}
