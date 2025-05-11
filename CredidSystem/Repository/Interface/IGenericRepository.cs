using CredidSystem.Entity;

namespace CredidSystem.Repository.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task <bool> DeleteAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsyn(int id);
    }
}
