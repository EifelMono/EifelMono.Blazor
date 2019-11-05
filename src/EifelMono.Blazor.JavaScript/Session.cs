using System;
using System.Threading.Tasks;
using EifelMono.Fluent.Log;
using Microsoft.JSInterop;

namespace EifelMono.Blazor.JavaScript
{
    public static class Session // www/SessionJSInterop.js
    {
        internal static string s_jSInteropName = "EifelMonoBlazorJavaScriptSessionJSInterop";
        public static async ValueTask<(bool Ok, T Value)> GetValueSafeAsync<T>(string key)
        {
            try
            {
                return (true, await Init.JSRuntime.InvokeAsync<T>($"{s_jSInteropName}.get", key));
            }
            catch (Exception ex)
            {
                ex.LogException();
                return (false, default);
            }
        }

        public static async ValueTask<T> GetValueAsync<T>(string key)
            => (await GetValueSafeAsync<T>(key)).Value;

        public static async ValueTask<bool> SetValueSafeAsync<T>(string key, T value)
        {
            try
            {
                await Init.JSRuntime.InvokeAsync<object>($"{s_jSInteropName}.set", key, value);
                return true;
            }
            catch (Exception ex)
            {
                ex.LogException();
                return false;
            }
        }

        public static async ValueTask SetValueAsync<T>(string key, T value)
            => await SetValueSafeAsync(key, value);

        public static async ValueTask<bool> DeleteKeySafeAsync(string key)
        {
            try
            {
                await Init.JSRuntime.InvokeAsync<object>($"{s_jSInteropName}.delete", key);
                return true;
            }
            catch (Exception ex)
            {
                ex.LogException();
                return false;
            }
        }

        public static async ValueTask DeleteKeyAsync(string key)
            => await DeleteKeySafeAsync(key);
    }
}
