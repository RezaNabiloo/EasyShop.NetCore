using BSG.EasyShop.Domain;
using BSG.EasyShop.Application.Contracts.Persistance;
using BSG.EasyShop.Persistence.Repositories.Common;

namespace BSG.EasyShop.Persistence.Repositories
{
    public class ProductGroupRepository : GenericRepository<ProductGroup>, IProductGroupRepository
    {
        private readonly EasyShopDbContext _context;

        public ProductGroupRepository(EasyShopDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
