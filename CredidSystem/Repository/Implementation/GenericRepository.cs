using System.Runtime.CompilerServices;
using CredidSystem.DB;
using CredidSystem.Entity;
using CredidSystem.Repository.Interface;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace CredidSystem.Repository.Implementation
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly CreditWebDB _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(CreditWebDB creditWebDB)
        {
            _context = creditWebDB;
            _dbSet = _context.Set<TEntity>(); 
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var data = await _dbSet.FindAsync(id);
            if (data == null)
            {
                return false;
            }
            data.IsDeleted = true;
            _dbSet.Update(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var datas = await _dbSet.Where(i => i.IsDeleted == false).AsNoTracking<TEntity>().ToListAsync();
            return datas;
        }

        public async Task<TEntity> GetByIdAsyn(int id)
        {
            await _dbSet.FindAsync(id);
            var data = await _dbSet.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id && !i.IsDeleted);
            return data;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            entity.UpdatedAt = DateTime.Now;
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
