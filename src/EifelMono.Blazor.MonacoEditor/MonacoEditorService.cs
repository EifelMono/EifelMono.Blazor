using EifelMono.Blazor.Core;
using Microsoft.Extensions.DependencyInjection;

namespace EifelMono.Blazor.MonacoEditor
{
    public class MonacoEditorHtml : BlazorComponentHtml
    {
        public override string GetHtml(BlazorComponentHtmlType htmlType, string typeName = null)
            => htmlType switch
            {
                BlazorComponentHtmlType.Css => Css,
                BlazorComponentHtmlType.Js => Js,
                BlazorComponentHtmlType.JsInterop => JsInterop,
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
            $"<script src = \"_content/{Name}/MonacoEditorJSInterop.js\"></script>";
    }

    public static class MonacoEditorServiceExtensions
    {
        public static IServiceCollection AddEifelMonoBlazorMonacoEditor(this IServiceCollection thisValue)
        {
            BlazorComponentHtmls.Instance.AddHtml(new MonacoEditorHtml());
            return thisValue;
        }
    }
}
