using AutoMapper;
using CredidSystem.Entity;
using CredidSystem.Models;
using CredidSystem.Repository.Interface;
using CredidSystem.Service.Interface;

namespace CredidSystem.Service.Implementation
{
    public class CategoryService : GenericService<CategoryViewModel, Category>, ICategoryService
    {
        protected readonly IGenericRepository<Category> _genericRepository;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> genericRepository, IMapper mapper) : base(mapper, genericRepository)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        
      
     
    }
    
    
}
