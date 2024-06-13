using BSG.EasyShop.Application.Contracts.Persistance.Common;
using BSG.EasyShop.Domain;

namespace BSG.EasyShop.Application.Contracts.Persistance
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        Task Confirm(Product product, bool confirmStatus);

    }
}
