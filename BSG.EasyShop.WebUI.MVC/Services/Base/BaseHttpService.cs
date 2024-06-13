using BSG.EasyShop.WebUI.MVC.Contracts;
using System.Net.Http.Headers;

namespace BSG.EasyShop.WebUI.MVC.Services.Base
{
    public class BaseHttpService
    {
        protected readonly IClient _client;
        protected readonly ILocalStorageService _localStorage;

        public BaseHttpService(IClient client, ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        // we convert api exception to readable errors for client
        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException exception)
        {
            if (exception.StatusCode == 400)
            {
                return new Response<Guid>() { Message = "Validation errors have occured", ValidationErrors = exception.Response, Success = false };
            }

            if (exception.StatusCode == 404)
            {
                return new Response<Guid>() { Message = "Not Found", ValidationErrors = exception.Response, Success = false };
            }
            else
            {
                return new Response<Guid>() { Message = "Sonething went wrong. try later please ...", ValidationErrors = exception.Response, Success = false };
            }
        }

        protected void AddBearerToken()
        {
            if (_localStorage.Exists("token"))
            {
                _client.HttpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _localStorage.GetStorageValue<string>("token"));
            }
        }
    }
}
