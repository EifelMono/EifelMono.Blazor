using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace EifelMono.Blazor.JavaScript
{

    public class SessionStorageJsInterop : Base.StorageBase
    {
        public SessionStorageJsInterop(IJSRuntime jSRuntime)
            : base(jSRuntime, "EifelMonoBlazorJavaScriptSessionStorageJsInterop") { }
    }
}
