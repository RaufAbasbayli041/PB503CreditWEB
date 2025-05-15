using CredidSystem.Entity;
using CredidSystem.Models;

namespace CredidSystem.Service.Interface
{
    public interface ICategoryService : IGenericService<CategoryViewModel,Category>
    {
        Task<CategoryViewModel> GetByIdAsync(int id);
        Task<IEnumerable<CategoryViewModel>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
        Task<CategoryViewModel> Update(CategoryViewModel viewModel);
        Task<CategoryViewModel> CreateAsync(CategoryViewModel viewModel);
    }
    
}
