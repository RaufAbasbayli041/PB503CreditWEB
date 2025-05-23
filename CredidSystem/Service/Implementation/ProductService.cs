using AutoMapper;
using CredidSystem.Entity;
using CredidSystem.Models;
using CredidSystem.Repository.Interface;
using CredidSystem.Service.Interface;

namespace CredidSystem.Service.Implementation
{
    public class ProductService : GenericService<ProductViewModel, Product>, IProductService

    {
        private readonly IProductRepository _productRepository;
              

        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IProductRepository productRepository)  :base(mapper, productRepository)
        {
            
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllWithIncludeAsync()
        {
           var products = await _productRepository.GetAllWithIncludeAsync();
            if (products == null)
            {
                return null;
            }
            var productViewModels = _mapper.Map<List<ProductViewModel>>(products);
            return productViewModels;
        }
    }
}
