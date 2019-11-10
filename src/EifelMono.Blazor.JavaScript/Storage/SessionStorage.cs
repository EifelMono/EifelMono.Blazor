using System.Threading.Tasks;

namespace EifelMono.Blazor.JavaScript.Storage
{
    public class SessionStorage
    {
        // www/Session/SessionStorageJSInterop.js
        private static readonly string s_jSPrefx = "EifelMonoBlazorJavaScriptSessionStorageJSInterop";
        private static readonly StorageJsInterop s_instance = new StorageJsInterop(s_jSPrefx);

        #region Exists
        public static ValueTask<(bool Ok, bool Value)> KeyExistsSafeAsync(string key)
            => s_instance.DeleteKeySafeAsync(key);

        public static ValueTask<bool> KeyExistsAsync(string key)
            => s_instance.KeyExistsAsync(key);
        #endregion


        #region Get
        public static ValueTask<(bool Ok, T Value)> GetValueSafeAsync<T>(string key)
            => s_instance.GetValueSafeAsync<T>(key);

        public static ValueTask<T> GetValueAsync<T>(string key)
            => s_instance.GetValueAsync<T>(key);
        #endregion

        #region Set
        public static ValueTask<(bool Ok, bool Value)> SetValueSafeAsync<T>(string key, T value)
            => s_instance.SetValueSafeAsync(key, value);

        public static ValueTask<bool> SetValueAsync<T>(string key, T value)
            => s_instance.SetValueAsync<T>(key, value);
        #endregion

        #region Delete
        public static ValueTask<(bool Ok, bool Value)> DeleteKeySafeAsync(string key)
            => s_instance.DeleteKeySafeAsync(key);

        public static ValueTask<bool> DeleteKeyAsync(string key)
            => s_instance.DeleteKeyAsync(key);
        #endregion
    }
}
