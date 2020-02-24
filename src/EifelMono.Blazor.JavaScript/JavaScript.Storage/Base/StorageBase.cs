using System;
using System.Threading.Tasks;
using EifelMono.Fluent.Log;
using Microsoft.JSInterop;

namespace EifelMono.Blazor.JavaScript.Base
{
    public class StorageBase : Core.Base.JsInteropBase
    {
        public StorageBase(IJSRuntime jSRuntime, string jSPrefix) : base(jSRuntime, jSPrefix) { }

        #region Exists
        public async ValueTask<(bool Ok, bool Value)> KeyExistsSafeAsync(string key)
        {
            try
            {
                return (true, await JSRuntime.InvokeAsync<bool>($"{JSPrefix}.exists", key).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                ex.LogException();
                return (false, false);
            }
        }

        public async ValueTask<bool> KeyExistsAsync(string key)
            => (await KeyExistsSafeAsync(key).ConfigureAwait(false)).Value;
        #endregion

        #region Get
        public async ValueTask<(bool Ok, T Value)> GetValueSafeAsync<T>(string key)
        {
            try
            {
                return (true, await JSRuntime.InvokeAsync<T>($"{JSPrefix}.get", key));
            }
            catch (Exception ex)
            {
                ex.LogException();
                return (false, default);
            }
        }

        public async ValueTask<T> GetValueAsync<T>(string key)
            => (await GetValueSafeAsync<T>(key).ConfigureAwait(false)).Value;
        #endregion

        #region Set
        public async ValueTask<(bool Ok, bool Value)> SetValueSafeAsync<T>(string key, T value)
        {
            try
            {
                return (true, await JSRuntime.InvokeAsync<bool>($"{JSPrefix}.set", key, value).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                ex.LogException();
                return (false, false);
            }
        }

        public async ValueTask<bool> SetValueAsync<T>(string key, T value)
            => (await SetValueSafeAsync(key, value).ConfigureAwait(false)).Value;
        #endregion

        #region Delete
        public async ValueTask<(bool Ok, bool Value)> DeleteKeySafeAsync(string key)
        {
            try
            {
                return (true, await JSRuntime.InvokeAsync<bool>($"{JSPrefix}.delete", key).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                ex.LogException();
                return (false, false);
            }
        }

        public async ValueTask<bool> DeleteKeyAsync(string key)
            => (await DeleteKeySafeAsync(key).ConfigureAwait(false)).Value;
        #endregion
    }
}
