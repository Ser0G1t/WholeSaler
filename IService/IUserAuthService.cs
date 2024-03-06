using WholeSaler.DTO;

namespace WholeSaler.IService
{
    public interface IUserAuthService
    {
        string AuthByJwt(LoginDTO dto);
        void RegisterUser(RegisterDTO dto);
    }
}
