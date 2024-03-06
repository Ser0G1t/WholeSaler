using WholeSaler.Entity;

namespace WholeSaler.IService
{
    public interface IContractorCrudService
    {
        Task<IEnumerable<User>> GetContractors();
    }
}
