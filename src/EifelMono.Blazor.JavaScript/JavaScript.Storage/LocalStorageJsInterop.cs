using Microsoft.JSInterop;

namespace EifelMono.Blazor.JavaScript
{
    public class LocalStorageJsInterop : Base.StorageBase
    {
        public LocalStorageJsInterop(IJSRuntime jSRuntime)
            : base(jSRuntime, "EifelMonoBlazorJavaScriptLocalStorageJsInterop") { }
    }
}
