using System;
using System.Threading.Tasks;
using EifelMono.Fluent.Log;
using Microsoft.JSInterop;

namespace EifelMono.Blazor.JavaScript.Base
{
    public class StorageBaseFixKey : StorageBase
    {
        public string Key { get; private set; }
        public StorageBaseFixKey(IJSRuntime jSRuntime, string jSPrefix, string key) : base(jSRuntime, jSPrefix)
        {
            Key = key;
        }

        #region Exists
        public ValueTask<(bool Ok, bool Value)> KeyExistsSafeAsync()
            => KeyExistsSafeAsync(Key);

        public ValueTask<bool> KeyExistsAsync()
            => KeyExistsAsync(Key);
        #endregion

        #region Get
        public ValueTask<(bool Ok, T Value)> GetValueSafeAsync<T>()
            => GetValueSafeAsync<T>(Key);

        public ValueTask<T> GetValueAsync<T>()
            => base.GetValueAsync<T>(Key);
        #endregion

        #region Set
        public ValueTask<(bool Ok, bool Value)> SetValueSafeAsync<T>(T value)
            => SetValueSafeAsync<T>(Key, value);

        public ValueTask<bool> SetValueAsync<T>(T value)
            => SetValueAsync<T>(Key, value);
        #endregion

        #region Delete
        public ValueTask<(bool Ok, bool Value)> DeleteKeySafeAsync()
            => DeleteKeySafeAsync(Key);

        public ValueTask<bool> DeleteKeyAsync()
            => DeleteKeyAsync(Key);
        #endregion
    }
}
