
using BSG.EasyShop.Domain;
using BSG.EasyShop.Application.Contracts.Persistance;
using BSG.EasyShop.Persistence.Repositories.Common;

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
            await _context.SaveChangesAsync();
        }
    }
}
