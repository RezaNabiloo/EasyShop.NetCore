using BSG.EasyShop.WebUI.MVC.Contracts;
using BSG.EasyShop.WebUI.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BSG.EasyShop.WebUI.MVC.Controllers
{
    [Authorize]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;            
        }
        // GET: BrandController
        public async Task<ActionResult> Index()
        {
            var data = await _brandService.GetBrands();
            return View(data);
        }

        // GET: BrandController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BrandController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BrandController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BrandCreateVM model)
        {
            try
            {
                var id=await _brandService.CreateBrand(model);
                return  RedirectToAction(nameof(Index));
            }
            catch
            {
                
            }
            return View(model);
        }

        // GET: BrandController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var data = await _brandService.GetBrand(id);
                return View(data);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        // POST: BrandController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, BrandVM model)
        {
            try
            {

                await _brandService.UpdateBrand(id, model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _brandService.DeleteBrand(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                throw;
            }
        }
    }
}
