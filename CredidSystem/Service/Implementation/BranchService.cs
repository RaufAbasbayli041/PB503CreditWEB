using AutoMapper;
using CredidSystem.Entity;
using CredidSystem.Models;
using CredidSystem.Repository.Interface;
using CredidSystem.Service.Interface;

namespace CredidSystem.Service.Implementation
{
    public class BranchService : GenericService<BranchViewModel, Branch>, IBranchService
    {
      private readonly IGenericRepository<Branch> _repository;
        private readonly IMapper _mapper;

        public BranchService(IMapper mapper, IGenericRepository<Branch> repository) : base(mapper, repository)
        {
            _repository = repository;
        }
      

        

    }
    
}
