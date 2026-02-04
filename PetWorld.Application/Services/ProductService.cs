using PetWorld.Domain.Entities;
using PetWorld.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetWorld.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IReadOnlyList<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }
    }
}
