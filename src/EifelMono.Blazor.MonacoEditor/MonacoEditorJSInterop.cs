using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace EifelMono.Blazor.MonacoEditor
{
    public static class MonacoEditorJSInterop
    {
        public static ValueTask<bool> InitializeEditorAsync(IJSRuntime runtime, MonacoEditorModel editorModel)
            => runtime.InvokeAsync<bool>("EifelMonoBlazorMonacoEditor.Editor.InitializeEditor", new[] { editorModel });

        public static ValueTask<string> GetValueAsync(IJSRuntime runtime, string id)
            => runtime.InvokeAsync<string>("EifelMonoBlazorMonacoEditor.Editor.GetValue", new[] { id });

        public static ValueTask<bool> SetValueAsync(IJSRuntime runtime, string id, string value)
            => runtime.InvokeAsync<bool>("EifelMonoBlazorMonacoEditor.Editor.SetValue", new[] { id, value });

        public static ValueTask<bool> SetThemeAsync(IJSRuntime runtime, string id, string theme)
            => runtime.InvokeAsync<bool>("EifelMonoBlazorMonacoEditor.Editor.SetTheme", new[] { id, theme });
    }
}
