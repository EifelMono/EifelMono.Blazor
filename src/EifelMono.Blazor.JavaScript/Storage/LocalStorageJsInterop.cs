using System;
using System.Threading.Tasks;
using EifelMono.Fluent.Log;
using Microsoft.JSInterop;
using EifelMono.Blazor.Core;

namespace EifelMono.Blazor.JavaScript.Storage
{
    public static class LocalStorageJsInterop // www/Storage/LocalStorageJSInterop.js
    {
        internal static string s_jSInteropName = "EifelMonoBlazorJavaScriptLocalStorageJSInterop";

        #region Exists
        public static async ValueTask<(bool Ok, bool Value)> KeyExistsSafeAsync(string key)
        {
            try
            {
                return (true, await HostHtmlInit.JSRuntime.InvokeAsync<bool>($"{s_jSInteropName}.exists", key).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                ex.LogException();
                return (false, false);
            }
        }

        public async static ValueTask<bool> KeyExistsAsync(string key)
            => (await KeyExistsSafeAsync(key).ConfigureAwait(false)).Value;
        #endregion

        #region Get
        public static async ValueTask<(bool Ok, T Value)> GetValueSafeAsync<T>(string key)
        {
            try
            {
                return (true, await HostHtmlInit.JSRuntime.InvokeAsync<T>($"{s_jSInteropName}.get", key));
            }
            catch (Exception ex)
            {
                ex.LogException();
                return (false, default);
            }
        }

        public static async ValueTask<T> GetValueAsync<T>(string key)
            => (await GetValueSafeAsync<T>(key).ConfigureAwait(false)).Value;
        #endregion

        #region Set
        public static async ValueTask<(bool Ok, bool Value)> SetValueSafeAsync<T>(string key, T value)
        {
            try
            {
                return (true, await HostHtmlInit.JSRuntime.InvokeAsync<bool>($"{s_jSInteropName}.set", key, value).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                ex.LogException();
                return (false, false);
            }
        }

        public async static ValueTask<bool> SetValueAsync<T>(string key, T value)
            => (await SetValueSafeAsync(key, value).ConfigureAwait(false)).Value;
        #endregion

        #region Delete
        public static async ValueTask<(bool Ok, bool Value)> DeleteKeySafeAsync(string key)
        {
            try
            {
                return (true, await HostHtmlInit.JSRuntime.InvokeAsync<bool>($"{s_jSInteropName}.delete", key).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                ex.LogException();
                return (false, false);
            }
        }

        public async static ValueTask<bool> DeleteKeyAsync(string key)
            => (await DeleteKeySafeAsync(key).ConfigureAwait(false)).Value;
        #endregion
    }
}
