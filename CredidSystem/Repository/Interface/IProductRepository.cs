using CredidSystem.Entity;

namespace CredidSystem.Repository.Interface
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        
        Task<List<Product>> GetAllWithInclude();

    }


}
