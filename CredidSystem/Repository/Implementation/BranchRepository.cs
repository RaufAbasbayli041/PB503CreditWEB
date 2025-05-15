using CredidSystem.DB;
using CredidSystem.Entity;
using CredidSystem.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CredidSystem.Repository.Implementation
{
    public class BranchRepository : GenericRepository<Branch>, IBranchRepository
    {
        public BranchRepository(CreditWebDB creditWebDB) : base(creditWebDB)
        {

        }

        public async Task<IEnumerable<Branch>> GetBranchesByMerchantIdAsync()
        {
            var branches = _context.Branches
                .Include(b => b.Merchant)
                .Where(b => b.MerchantId != null && b.IsDeleted == false)
                .AsNoTracking()
                .ToListAsync();
            return await branches;


        }
    }
    
    
}
