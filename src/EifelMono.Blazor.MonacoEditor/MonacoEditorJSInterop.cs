using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace EifelMono.Blazor.MonacoEditor
{
    public class MonacoEditorJsInterop : Core.Base.JsInteropBase
    {
        public MonacoEditorJsInterop(IJSRuntime jSRuntime) : base(jSRuntime, "EifelMonoBlazorMonacoEditorJsInterop") { }
        public ValueTask<bool> InitializeEditorAsync(MonacoEditorModel editorModel)
            => JSRuntime.InvokeAsync<bool>($"{JSPrefix}.Editor.InitializeEditor", new[] { editorModel });

        public ValueTask<string> GetValueAsync(string id)
            => JSRuntime.InvokeAsync<string>($"{JSPrefix}.Editor.GetValue", new[] { id });

        public ValueTask<bool> SetValueAsync(string id, string value)
            => JSRuntime.InvokeAsync<bool>($"{JSPrefix}.Editor.SetValue", new[] { id, value });

        public ValueTask<bool> SetThemeAsync(string id, string theme)
            => JSRuntime.InvokeAsync<bool>($"{JSPrefix}.Editor.SetTheme", new[] { id, theme });
    }
}
