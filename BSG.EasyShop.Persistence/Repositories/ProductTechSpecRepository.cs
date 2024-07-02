
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Domain;
using BSG.EasyShop.Persistence.Repositories.Common;

namespace BSG.EasyShop.Persistence.Repositories
{
    public class ProductTechSpecRepository : GenericRepository<ProductTechSpec>, IProductTechSpecRepository
    {
        private readonly EasyShopDbContext _context;

        public ProductTechSpecRepository(EasyShopDbContext context) : base(context)
        {
            _context = context;
        }

        
    }
}
