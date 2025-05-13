using AutoMapper;
using CredidSystem.Entity;
using CredidSystem.Repository.Interface;
using CredidSystem.Service.Interface;

namespace CredidSystem.Service.Implementation
{
    public class GenericService<TModel, TEntity> : IGenericService<TModel, TEntity> where TEntity : BaseEntity where TModel : class, new()
    {
        private readonly IGenericRepository<TEntity> _genericRepository;
        private readonly IMapper _mapper;

        public GenericService(IMapper mapper, IGenericRepository<TEntity> genericRepository)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
        }

        public async Task<TModel> CreateAsync(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            var result = await _genericRepository.CreateAsync(entity);
            if (result == null)
            {
                return null;
            }
            var dto = _mapper.Map<TModel>(result);

            return dto;
        }

        public async Task<bool> DeleteAsync(int id) => await _genericRepository.DeleteAsync(id);
     
        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            var entities = await _genericRepository.GetAllAsync();
            if (entities == null)
            {
                return null;
            }
            var models = _mapper.Map<IEnumerable<TModel>>(entities);
            return models;
        }

        public async Task<TModel> GetByIdAsync(int id)
        {
            var entity = await _genericRepository.GetByIdAsyn(id);
            if (entity == null)
            {
                return null;
            }
            var model = _mapper.Map<TModel>(entity);
            return model;
        }

        public async Task<TModel> Update(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            var result = await _genericRepository.Update(entity);
            if (result == null)
            {
                return null;
            }
            var dto = _mapper.Map<TModel>(result);
            return model;
        }
    }

}
