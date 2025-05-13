using AutoMapper;
using CredidSystem.Entity;
using CredidSystem.Models;
using CredidSystem.Repository.Interface;
using CredidSystem.Service.Interface;

namespace CredidSystem.Service.Implementation
{
    public class MerchantService : GenericService<MerchantViewModel, Merchant>, IMerchantService
    {
        private readonly IGenericRepository<Merchant> _repository;
        private readonly IMapper _mapper;

        public MerchantService(IMapper mapper, IGenericRepository<Merchant>  repository) : base(mapper, repository)
        {
            
        }
                
       
      

    }


}
