using Microsoft.JSInterop;

namespace EifelMono.Blazor.Core.Base
{
    public class JsInteropBase
    {
        protected IJSRuntime JSRuntime { get; set; }
        protected string JSPrefix { get; set; }
        public JsInteropBase(IJSRuntime jSRuntime, string jSPrefix)
        {
            JSRuntime = jSRuntime;
            JSPrefix = jSPrefix;
        }

        public bool IsJSRuntime => JSRuntime is { };
    }
}
