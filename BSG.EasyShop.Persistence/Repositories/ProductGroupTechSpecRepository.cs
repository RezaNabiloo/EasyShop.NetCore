using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Domain;
using BSG.EasyShop.Persistence.Repositories.Common;

namespace BSG.EasyShop.Persistence.Repositories
{
    public class ProductGroupTechSpecRepository : GenericRepository<ProductGroupTechSpec>, IProductGroupTechSpecRepository
    {
        private readonly EasyShopDbContext _context;

        public ProductGroupTechSpecRepository(EasyShopDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
