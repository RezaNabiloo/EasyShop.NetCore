using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Domain;
using BSG.EasyShop.Persistence.Repositories.Common;

namespace BSG.EasyShop.Persistence.Repositories
{
    public class ProvinceRepository : GenericRepository<Province>, IProvinceRepository
    {
        private readonly EasyShopDbContext _context;

        public ProvinceRepository(EasyShopDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
