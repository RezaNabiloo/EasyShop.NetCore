using BSG.EasyShop.WebUI.MVC.Contracts;
using Hanssens.Net;
namespace BSG.EasyShop.WebUI.MVC.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        LocalStorage _localStorage;

        public LocalStorageService()
        {
            // create configuration for local storage
            var config = new LocalStorageConfiguration()
            {
                AutoLoad = true,
                AutoSave = true,
                Filename = "BSG.EasyShop.LocalStorage"
            };

            // set configuration for _localStorage
            _localStorage = new LocalStorage(config);

        }


        public void ClearStorage(List<string> keys)
        {
            foreach (var key in keys)
            {
                _localStorage.Remove(key);
            }
        }

        public bool Exists(string key)
        {
            return _localStorage.Exists(key);
        }

        public T GetStorageValue<T>(string key)
        {
            return _localStorage.Get<T>(key);
        }

        public void SetStorageValue<T>(string key, T value)
        {
            _localStorage.Store<T>(key, value);
            _localStorage.Persist();
        }
    }
}
