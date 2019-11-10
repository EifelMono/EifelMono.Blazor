using System;
using System.Threading.Tasks;
using EifelMono.Blazor.Core;
using EifelMono.Fluent.Log;
using Microsoft.JSInterop;

namespace EifelMono.Blazor.JavaScript
{
    public class StorageJsInterop
    {
        protected string _jSPrefix;
        public StorageJsInterop(string jSPrefix)
        {
            _jSPrefix = jSPrefix;
        }

        #region Exists
        public async ValueTask<(bool Ok, bool Value)> KeyExistsSafeAsync(string key)
        {
            try
            {
                return (true, await HostHtmlInit.JSRuntime.InvokeAsync<bool>($"{_jSPrefix}.exists", key).ConfigureAwait(false));
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
                return (true, await HostHtmlInit.JSRuntime.InvokeAsync<T>($"{_jSPrefix}.get", key));
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
                return (true, await HostHtmlInit.JSRuntime.InvokeAsync<bool>($"{_jSPrefix}.set", key, value).ConfigureAwait(false));
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
                return (true, await HostHtmlInit.JSRuntime.InvokeAsync<bool>($"{_jSPrefix}.delete", key).ConfigureAwait(false));
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
