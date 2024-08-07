﻿using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Domain;
using BSG.EasyShop.Persistence.Repositories.Common;

namespace BSG.EasyShop.Persistence.Repositories
{
    public class ProductGroupSizeRepository : GenericRepository<ProductGroupSize>, IProductGroupSizeRepository
    {
        private readonly EasyShopDbContext _context;

        public ProductGroupSizeRepository(EasyShopDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
