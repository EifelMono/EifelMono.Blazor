using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace EifelMono.Blazor.JavaScript
{
    public class MessageBoxJsInterop : Core.Base.JsInteropBase
    {
        public MessageBoxJsInterop(IJSRuntime jSRuntime) : base(jSRuntime, "EifelMonoBlazorJavaScriptMessageBoxJsInterop") { }

        public ValueTask<object> ShowAsync(string text)
            => JSRuntime.InvokeAsync<object>($"{JSPrefix}.Show", new[] { text });
    }
}
