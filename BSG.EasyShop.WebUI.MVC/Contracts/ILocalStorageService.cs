namespace BSG.EasyShop.WebUI.MVC.Contracts
{
    public interface ILocalStorageService
    {
        void ClearStorage(List<string> keys);

        T GetStorageValue<T>(string key);

        void SetStorageValue<T>(string key, T value);

        bool Exists(string key);
    }
}
