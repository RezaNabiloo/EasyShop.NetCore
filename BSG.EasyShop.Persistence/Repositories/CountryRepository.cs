using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Domain;
using BSG.EasyShop.Persistence.Repositories.Common;

namespace BSG.EasyShop.Persistence.Repositories
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        private readonly EasyShopDbContext _context;

        public CountryRepository(EasyShopDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
