using AutoMapper;
using CredidSystem.Entity;
using CredidSystem.Models;
using CredidSystem.Repository.Interface;
using CredidSystem.Service.Interface;

namespace CredidSystem.Service.Implementation
{
    public class ProductService : GenericService<ProductViewModel,Product> , IProductService

    {
        protected readonly IGenericRepository<Product> _genericRepository;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IGenericRepository<Product> genericRepository)  :base(mapper, genericRepository)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        
       
    }
}
