using Microsoft.JSInterop;

namespace EifelMono.Blazor.JavaScript
{
    public static class MessageBoxExtensions
    {
        public static MessageBoxJsInterop MessageBox(this IJSRuntime thisValue)
            => new MessageBoxJsInterop(thisValue);
    }
}
