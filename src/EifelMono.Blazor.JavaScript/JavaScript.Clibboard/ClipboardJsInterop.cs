using System;
using System.Threading.Tasks;
using EifelMono.Fluent.Log;
using Microsoft.JSInterop;

namespace EifelMono.Blazor.JavaScript
{
    public class ClipboardJsInterop : Core.Base.JsInteropBase
    {

        public ClipboardJsInterop(IJSRuntime jSRuntime) : base(jSRuntime, "EifelMonoBlazorJavaScriptClipboardJsInterop") { }
        // https://flaviocopes.com/clipboard-api/
        // wwwroot/ClipBoardJSInterop.js

        // does not work PREMISSION!!!!
        public async ValueTask<bool> WriteTextAsync(string text)
        {
            try
            {
                return await JSRuntime.InvokeAsync<bool>($"{JSPrefix}.WriteText", new[] { text });
            }
            catch (Exception ex)
            {
                ex.LogException();
            }
            return false;
        }
    }
}
