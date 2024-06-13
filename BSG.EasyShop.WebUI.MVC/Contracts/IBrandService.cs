using BSG.EasyShop.WebUI.MVC.Models;
using BSG.EasyShop.WebUI.MVC.Services.Base;

namespace BSG.EasyShop.WebUI.MVC.Contracts
{
    public interface IBrandService
    {
        Task<BrandVM> GetBrand(long id);
        Task<List<BrandVM>> GetBrands();
        Task<Response<long>> CreateBrand(BrandCreateVM model);

        Task<Response<long>> UpdateBrand(long id, BrandVM model);
        Task<Response<long>> DeleteBrand(long id);
    }
}
