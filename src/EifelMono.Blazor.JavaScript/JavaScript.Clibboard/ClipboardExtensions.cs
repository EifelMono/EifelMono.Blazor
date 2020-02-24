using Microsoft.JSInterop;

namespace EifelMono.Blazor.JavaScript
{
    public static class ClipboardExtensions
    {
        public static ClipboardJsInterop Clipboard(this IJSRuntime thisValue)
            => new ClipboardJsInterop(thisValue);
    }
}
