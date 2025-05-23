using CredidSystem.DB;
using CredidSystem.Entity;
using CredidSystem.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CredidSystem.Repository.Implementation
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(CreditWebDB context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetAllWithIncludeAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Branch)
                .Where(p => !p.IsDeleted)
                .AsNoTracking()
                .ToListAsync();
        }

      
    }


}
