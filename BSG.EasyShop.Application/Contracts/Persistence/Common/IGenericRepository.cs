namespace BSG.EasyShop.Application.Contracts.Persistance.Common
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByKey(long id);
        Task<IReadOnlyList<T>> GetAll();
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Remove(T entity);
        Task<bool> Exist(long id);
            
    }
}
