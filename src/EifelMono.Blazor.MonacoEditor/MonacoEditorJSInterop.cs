using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace EifelMono.Blazor.MonacoEditor
{
    public class MonacoEditorJSInterop
    {
        internal static readonly string s_jSPrefix = "EifelMonoBlazorMonacoEditor";
        public static ValueTask<bool> InitializeEditorAsync(MonacoEditorModel editorModel)
            => Core.HostHtmlInit.JSRuntime.InvokeAsync<bool>($"{s_jSPrefix}.Editor.InitializeEditor", new[] { editorModel });

        public static ValueTask<string> GetValueAsync(string id)
            => Core.HostHtmlInit.JSRuntime.InvokeAsync<string>($"{s_jSPrefix}.Editor.GetValue", new[] { id });

        public static ValueTask<bool> SetValueAsync(string id, string value)
            => Core.HostHtmlInit.JSRuntime.InvokeAsync<bool>($"{s_jSPrefix}.Editor.SetValue", new[] { id, value });

        public static ValueTask<bool> SetThemeAsync(string id, string theme)
            => Core.HostHtmlInit.JSRuntime.InvokeAsync<bool>($"{s_jSPrefix}.Editor.SetTheme", new[] { id, theme });
    }
}
