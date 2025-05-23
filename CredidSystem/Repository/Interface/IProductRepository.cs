using CredidSystem.Entity;

namespace CredidSystem.Repository.Interface
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        
        Task<IEnumerable<Product>> GetAllWithIncludeAsync();

    }


}
