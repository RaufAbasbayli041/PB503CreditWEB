using CredidSystem.DB;
using CredidSystem.Entity;
using CredidSystem.Repository.Interface;

namespace CredidSystem.Repository.Implementation
{
    public class BranchRepository : GenericRepository<Branch>, IBranchRepository
    {
        public BranchRepository(CreditWebDB creditWebDB) : base(creditWebDB)
        {

        }
    }
    
    
}
