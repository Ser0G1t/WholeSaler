using Microsoft.EntityFrameworkCore;
using WholeSaler.Context;
using WholeSaler.Entity;
using WholeSaler.Exceptions;
using WholeSaler.IRepository;

namespace WholeSaler.Repository
{
   public abstract class CoreRepository<T> : ICoreRepository<T> where T : CoreEntity
    {
        protected readonly CoreContext _context;
        protected DbSet<T> _entities;
        public CoreRepository(CoreContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public virtual async Task Delete(long id)
        {
            var entity = await _entities.FindAsync(id);
            nullEntityValidator(entity);
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> FindAll()
        {
            return await _entities.AsNoTracking().ToListAsync();
        }

        public virtual async Task <T> GetById(long id)
        {
            var entity = await _entities.FindAsync(id);
            nullEntityValidator(entity);
            return entity;
        }

        public virtual async Task Insert(T entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Update(T entity)
        {
            nullEntityValidator(entity);
            await _context.SaveChangesAsync();
        }
        private void nullEntityValidator(T? entity)
        {
            if (entity is null)
            {
                throw new EntityNotFoundException("Entity with this id can't be find");
            }
        }
    }
}
