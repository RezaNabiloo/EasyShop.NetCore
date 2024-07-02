using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Domain;
using BSG.EasyShop.Persistence.Repositories.Common;

namespace BSG.EasyShop.Persistence.Repositories
{
    public class ColorRepository : GenericRepository<Color>, IColorRepository
    {
        private readonly EasyShopDbContext _context;

        public ColorRepository(EasyShopDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
