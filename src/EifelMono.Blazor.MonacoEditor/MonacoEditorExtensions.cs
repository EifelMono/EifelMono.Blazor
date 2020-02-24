using Microsoft.JSInterop;

namespace EifelMono.Blazor.MonacoEditor

{
    public static class MoncaoEditorExtensions
    {
        public static MonacoEditorJsInterop MonacoEditor(this IJSRuntime thisValue)
            => new MonacoEditorJsInterop(thisValue);
    }
}
