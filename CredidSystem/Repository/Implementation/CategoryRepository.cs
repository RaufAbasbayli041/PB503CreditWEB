using CredidSystem.DB;
using CredidSystem.Entity;
using CredidSystem.Repository.Interface;

namespace CredidSystem.Repository.Implementation
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(CreditWebDB context) : base(context)
        {
        }
    }
    
}
