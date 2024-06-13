using BSG.EasyShop.Application.Models.Identity;

namespace BSG.EasyShop.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<RegistrationResponse> Register(RegistrationRequest request);
        Task<AuthResponse> Login(AuthRequest request);        
    }
}
