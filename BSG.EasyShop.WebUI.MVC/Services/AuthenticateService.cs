using BSG.EasyShop.WebUI.MVC.Contracts;
using BSG.EasyShop.WebUI.MVC.Models;
using BSG.EasyShop.WebUI.MVC.Services.Base;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BSG.EasyShop.WebUI.MVC.Services
{
    public class AuthenticateService : BaseHttpService, IAuthenticateService
    {
        
        private IHttpContextAccessor _httpContextAccessor;
        private JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        public AuthenticateService(IClient client,
            ILocalStorageService localStorage,
            IHttpContextAccessor httpContextAccessor
            )  : base(client, localStorage)
        {        
            _httpContextAccessor = httpContextAccessor;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }
        public async Task<bool> Authenticate(string email, string password)
        {
            try
            {
                AuthRequest authenticationRequest = new()
                {
                    Email = email,
                    Password = password
                };

                var authenticationResponse = await _client.LoginAsync(authenticationRequest);
                if (authenticationResponse.Token!= string.Empty)
                {
                    var tokenContent = _jwtSecurityTokenHandler.ReadJwtToken(authenticationResponse.Token);
                    var claims = ParseClaims(tokenContent);
                    var user = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
                    var login = _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user);

                    _localStorage.SetStorageValue("token", authenticationResponse.Token);
                    return true;
                }
                return false;
            }
            catch 
            {

                return false;
            }
        }

        public async Task Logout()
        {
            _localStorage.ClearStorage(new List<string>() { "token" });
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public async Task<bool> Register(RegisterVM register)
        {
            RegistrationRequest registrationRequest = new()
            {
                UserName=register.UserName,
                Email = register.Email,
                FirstName = register.FirstName,
                LastName = register.LastName,
                Password = register.Password
            };

            var response = await _client.RegisterAsync(registrationRequest);

            if (!string.IsNullOrEmpty(response.UserName))
            {
                return true;
            }
            return false;
        }

        private IList<Claim> ParseClaims(JwtSecurityToken token)
        {
            var claims = token.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, token.Subject));
            return claims;
        }
    }
}
