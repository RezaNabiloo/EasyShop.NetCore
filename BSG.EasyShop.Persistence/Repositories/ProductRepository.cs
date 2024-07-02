
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Domain;
using BSG.EasyShop.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace BSG.EasyShop.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly EasyShopDbContext _context;

        public ProductRepository(EasyShopDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task Confirm(Product product, bool confirmStatus)
        {
            product.IsConfirmed = confirmStatus;
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
