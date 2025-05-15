using CredidSystem.Entity;

namespace CredidSystem.Repository.Interface
{
    public interface IBranchRepository : IGenericRepository<Branch>
    {
        // Add any additional methods specific to Branch repository here
        // For example:
       Task<IEnumerable<Branch>> GetBranchesByMerchantIdAsync();

    }

}
