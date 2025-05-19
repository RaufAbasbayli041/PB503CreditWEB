using AutoMapper;
using CredidSystem.Entity;
using CredidSystem.Models;
using CredidSystem.Repository.Implementation;
using CredidSystem.Repository.Interface;
using CredidSystem.Service.Interface;

namespace CredidSystem.Service.Implementation
{
    public class BranchService : GenericService<BranchViewModel, Branch>, IBranchService
    {
       
        private readonly IBranchRepository  _branchRepository;  
        private readonly IMapper _mapper;

        public BranchService(IMapper mapper,  IBranchRepository branchRepository) : base(mapper, branchRepository)
        {
            _mapper = mapper;
         
            _branchRepository = branchRepository;
        }



        public async Task<List<BranchViewModel>> GetAllWithIncudeAsync()
        {
            var entities = await _branchRepository.GetAllWithInclude();
            if (entities == null)
            {
                return null;
            }
            var models = _mapper.Map<List<BranchViewModel>>(entities);
            return models;
        }
    }
    
}
