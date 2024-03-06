using WholeSaler.Entity;

namespace WholeSaler.IRepository
{
    public interface ICoreRepository<T> where T : CoreEntity
    {
        Task<T> GetById(long id);
        Task<IEnumerable<T>> FindAll();
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(long id);
    }
}
