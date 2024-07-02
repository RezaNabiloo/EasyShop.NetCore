﻿using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Domain;
using BSG.EasyShop.Persistence.Repositories.Common;

namespace BSG.EasyShop.Persistence.Repositories
{
    public class TownshipRepository : GenericRepository<Township>, ITownshipRepository
    {
        private readonly EasyShopDbContext _context;

        public TownshipRepository(EasyShopDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
