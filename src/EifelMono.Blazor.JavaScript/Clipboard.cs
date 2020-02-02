using System;
using System.Threading.Tasks;
using EifelMono.Fluent.Log;

namespace EifelMono.Blazor.JavaScript
{
    public class Clipboard
    {
        // https://flaviocopes.com/clipboard-api/
        // wwwroot/ClipBoardJSInterop.js
        private static readonly string s_jSPrefix = "EifelMonoBlazorJavaScriptClipboardJSInterop";

        // do es not work PREMISSION!!!!
        public async static ValueTask<bool> WriteTextAsync(string text)
        {
            try
            {
                return await Core.HostHtmlInit.JSRuntime.InvokeAsync<bool>($"{s_jSPrefix}.WriteText", new[] { text });
            }
            catch (Exception ex)
            {
                ex.LogException();
            }
            return false;
        }
    }
}
