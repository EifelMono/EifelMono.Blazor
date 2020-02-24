using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace EifelMono.Blazor.JavaScript
{

    public class SessionStorageJsInterop : Base.StorageBase
    {
        public SessionStorageJsInterop(IJSRuntime jSRuntime)
            : base(jSRuntime, "EifelMonoBlazorJavaScriptSessionStorageJsInterop") { }
    }

    public class SessionStorageFixKeyJsInterop : Base.StorageBaseFixKey
    {
        public SessionStorageFixKeyJsInterop(IJSRuntime jSRuntime, string key)
            : base(jSRuntime, "EifelMonoBlazorJavaScriptSessionStorageJsInterop", key) { }
    }
}
