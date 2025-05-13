using CredidSystem.DB;
using CredidSystem.Entity;
using CredidSystem.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CredidSystem.Repository.Implementation
{
    public class MerchantRepos : GenericRepository<Merchant>, IMerchantRepo
    {
        public MerchantRepos(CreditWebDB creditWebDB) : base(creditWebDB)
        {
        }
    }

}
