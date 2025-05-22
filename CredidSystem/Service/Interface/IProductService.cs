using CredidSystem.Entity;
using CredidSystem.Models;

namespace CredidSystem.Service.Interface
{
    public interface IProductService : IGenericService<ProductViewModel, Product>
    {
        Task<ProductViewModel> GetByIdAsync(int id);
        Task<IEnumerable<ProductViewModel>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
        Task<ProductViewModel> Update(ProductViewModel viewModel);
        Task<ProductViewModel> CreateAsync(ProductViewModel viewModel);
       
        Task<List<ProductViewModel>> GetAllWithIncudeAsync();


    }
    
    
}
