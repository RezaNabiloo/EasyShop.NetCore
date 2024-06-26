namespace BSG.EasyShop.Application.Contracts.Persistance.Common
{
    public interface IGenericRepository<T> where T : class
    {
        Task< T?> GetItemByKey(long id);
        Task<IReadOnlyList<T>> GetAllItems();
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Remove(T entity);
        Task<bool> Exist(long id);
            
    }
}
