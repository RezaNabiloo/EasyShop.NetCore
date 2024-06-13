using AutoMapper;
using BSG.EasyShop.WebUI.MVC.Contracts;
using BSG.EasyShop.WebUI.MVC.Models;
using BSG.EasyShop.WebUI.MVC.Services.Base;
using Microsoft.AspNetCore.Authorization;

namespace BSG.EasyShop.WebUI.MVC.Services
{
    [Authorize]
    public class BrandService:BaseHttpService, IBrandService
    {
        private readonly IMapper _mapper;
        private readonly IClient _httpClient;
        private readonly ILocalStorageService _localStorageService;        

        public BrandService(IMapper mapper, IClient httpClient, ILocalStorageService localStorageService):base(httpClient,localStorageService)
        {
            _mapper = mapper;
            _httpClient = httpClient;
            _localStorageService = localStorageService;            
        }

        public async Task<BrandVM> GetBrand(long id)
        {
            var response = new Response<BrandVM>();
            AddBearerToken();
            var brand = await _client.BrandGETAsync(id);

            return _mapper.Map<BrandVM>(brand);
        }

        public async Task<Response<long>> CreateBrand(BrandCreateVM model)
        {
            var response = new Response<long>();
            try
            {                
                BrandCreateDTO brandCreateDTO = _mapper.Map<BrandCreateDTO>(model);
                AddBearerToken();
                var apiResponse = await _client.BrandPOSTAsync(brandCreateDTO);
                if (apiResponse > 0)
                {
                    response.Data = apiResponse;
                    response.Success = true;
                    response.Message = "Ctreation successfull";
                }
                else 
                {
                    response.Data = 0;
                    response.Success = false;
                    response.Message = "Creation failed";

                    //foreach (var err in apiResponse.Errors)
                    //{
                    //    response.ValidationErrors += err + Environment.NewLine;
                    //}
                }

            }
            catch (ApiException ex)
            {

                return ConvertApiExceptions<long>(ex);
            }


            return response;
        }

        public async Task<Response<long>> UpdateBrand(long id,BrandVM model)
        {
            try
            {
                BrandUpdateDTO brand = _mapper.Map<BrandUpdateDTO>(model);
                await _client.BrandPUTAsync(id, brand);
                return new Response<long> { Success = true, Data=id };
            }
            catch (ApiException ex)
            {

                return ConvertApiExceptions<long>(ex);
            }

        }

        public async Task<List<BrandVM>> GetBrands()
        {
            try
            {
                AddBearerToken();
                var brands = await _client.BrandAllAsync();
                return _mapper.Map<List<BrandVM>>(brands);

            }
            catch (ApiException ex)
            {
                //return ConvertApiExceptions<long>(ex);
            }

            return new List<BrandVM>();
        }

        public async Task<Response<long>> DeleteBrand(long id)
        {
            var response = new Response<long>();
            try
            {
                AddBearerToken();
                await _client.BrandDELETEAsync(id);
                response.Success = true;
                response.Data = id;
                response.Message = "Deletation success";

            }
            catch (ApiException ex)
            {

                return ConvertApiExceptions<long>(ex);
            }

            return response;
        }

        
    }
}
