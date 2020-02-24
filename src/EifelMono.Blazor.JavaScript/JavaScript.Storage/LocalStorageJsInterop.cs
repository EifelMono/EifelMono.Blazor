using Microsoft.JSInterop;

namespace EifelMono.Blazor.JavaScript
{
    public class LocalStorageJsInterop : Base.StorageBase
    {
        public LocalStorageJsInterop(IJSRuntime jSRuntime)
            : base(jSRuntime, "EifelMonoBlazorJavaScriptLocalStorageJsInterop") { }
    }

    public class LocalStorageFixKeyJsInterop : Base.StorageBaseFixKey
    {
        public LocalStorageFixKeyJsInterop(IJSRuntime jSRuntime, string key)
            : base(jSRuntime, "EifelMonoBlazorJavaScriptLocalStorageJsInterop", key) { }
    }
}
