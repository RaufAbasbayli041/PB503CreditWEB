using CredidSystem.Entity;
using CredidSystem.Models;

namespace CredidSystem.Service.Interface
{
    public interface IBranchService : IGenericService<BranchViewModel, Branch>
    {
        Task<BranchViewModel> GetByIdAsync(int id);
        Task<IEnumerable<BranchViewModel>> GetAllAsync();
        Task<List<BranchViewModel>> GetAllWithIncudeAsync();
        Task<bool> DeleteAsync(int id);
        Task<BranchViewModel> Update(BranchViewModel viewModel);
        Task<BranchViewModel> CreateAsync(BranchViewModel viewModel);
    }
}
