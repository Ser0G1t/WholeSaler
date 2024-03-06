using WholeSaler.Entity;

namespace WholeSaler.IService
{
    public interface IUserContextService
    {
        Task<User> GetUser();
        Task<bool> IsUserManager();
    }
}
