using System.ComponentModel.DataAnnotations;

namespace BSG.EasyShop.WebUI.MVC.Models
{
    public class BrandCreateVM
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string ImagePath { get; set; }
    }
}
