using zesty_api.Models;

namespace zesty_api.Interfaces
{
    public interface IAuthService
    {
        User Register(User user);
        string Login(LoginUser user);
    }
}
