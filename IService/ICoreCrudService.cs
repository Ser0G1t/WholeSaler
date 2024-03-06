using WholeSaler.Entity;

namespace WholeSaler.IService
{
    public interface ICoreCrudService<T> where T : CoreEntity
    {
        Task<T> GetById(long id);
        Task<IEnumerable<T>> FindAll();
        Task Insert(T entity);
        Task Update(long id, T entity);
        Task Delete(long id);
    }
}
