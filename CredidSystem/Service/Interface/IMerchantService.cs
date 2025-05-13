using CredidSystem.Entity;
using CredidSystem.Models;

namespace CredidSystem.Service.Interface
{
    public interface IMerchantService : IGenericService<MerchantViewModel,Merchant>

    {
        Task<MerchantViewModel> GetByIdAsync(int id);
        Task<IEnumerable<MerchantViewModel>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
        Task<MerchantViewModel> Update(MerchantViewModel viewModel);
        Task<MerchantViewModel> CreateAsync(MerchantViewModel viewModel);
    }

}
