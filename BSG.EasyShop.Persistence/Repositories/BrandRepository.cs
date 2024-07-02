using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Domain;
using BSG.EasyShop.Persistence.Repositories.Common;

namespace BSG.EasyShop.Persistence.Repositories
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        private readonly EasyShopDbContext _context;

        public BrandRepository(EasyShopDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
