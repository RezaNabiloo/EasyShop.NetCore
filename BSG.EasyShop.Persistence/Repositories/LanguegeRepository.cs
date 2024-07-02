using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Domain;
using BSG.EasyShop.Persistence.Repositories.Common;

namespace BSG.EasyShop.Persistence.Repositories
{
    public class LanguegeRepository : GenericRepository<Languege>, ILanguegeRepository
    {
        private readonly EasyShopDbContext _context;

        public LanguegeRepository(EasyShopDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
