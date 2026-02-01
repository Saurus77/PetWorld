using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetWorld.Domain.Entities;
using PetWorld.Domain.Repositories;
using PetWorld.Infrastructure.Data;

namespace PetWorld.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly PetWorldDbContext _dbContext;

        public ProductRepository(PetWorldDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Domain.Entities.Product>> GetAllAsync()
        {
            return await _dbContext.Products.AsNoTracking().ToListAsync();
        }

        Task<IReadOnlyList<Product>> IProductRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
