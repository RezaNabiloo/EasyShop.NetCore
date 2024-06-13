using BSG.EasyShop.WebUI.MVC.Models;

namespace BSG.EasyShop.WebUI.MVC.Contracts
{
    public interface IAuthenticateService
    {
        Task<bool> Authenticate(string email, string password);
        Task<bool> Register(RegisterVM register);
        Task Logout();
    }
}
