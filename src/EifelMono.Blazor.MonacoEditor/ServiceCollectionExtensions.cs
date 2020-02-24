using EifelMono.Blazor.Core;
using Microsoft.Extensions.DependencyInjection;

namespace EifelMono.Blazor.MonacoEditor
{
    public class MonacoEditorEntry : HostHtmlEntry
    {
        public override string GetHtml(HostHtmlEntryType initType, string otherName = null)
            => initType switch
            {
                HostHtmlEntryType.Css => Css,
                HostHtmlEntryType.Js => Js,
                HostHtmlEntryType.JsInterop => JsInterop,
                _ => ""
            };

        private string Css =>
            $"<link rel=\"stylesheet\" data-name=\"vs/editor/editor.main\" href=\"_content/{Name}/monaco-editor/min/vs/editor/editor.main.css\"/>";

        private string Js =>
            $"<script> var require = {{ paths: {{ 'vs': '_content/{Name}/monaco-editor/min/vs' }} }};</script>"
            + $"\r\n<script src = \"_content/{Name}/monaco-editor/min/vs/loader.js\" ></script>"
            + $"\r\n<script src = \"_content/{Name}/monaco-editor/min/vs/editor/editor.main.nls.js\"></script>"
            + $"\r\n<script src = \"_content/{Name}/monaco-editor/min/vs/editor/editor.main.js\" ></script>";
        private string JsInterop =>
            $"<script src = \"_content/{Name}/MonacoEditorJsInterop.js\"></script>";
    }

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEifelMonoBlazorMonacoEditor(this IServiceCollection thisValue)
        {
            HostHtmlGlobals.RegisterEntry(new MonacoEditorEntry());
            return thisValue;
        }
    }
}
