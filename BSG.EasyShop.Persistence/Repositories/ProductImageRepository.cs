
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Domain;
using BSG.EasyShop.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace BSG.EasyShop.Persistence.Repositories
{
    public class ProductImageRepository : GenericRepository<ProductImage>, IProductImageRepository
    {
        private readonly EasyShopDbContext _context;

        public ProductImageRepository(EasyShopDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
