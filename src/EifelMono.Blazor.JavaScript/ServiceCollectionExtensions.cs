using EifelMono.Blazor.Core;
using Microsoft.Extensions.DependencyInjection;

namespace EifelMono.Blazor.JavaScript
{
    internal class JavaScriptEntry : HostHtmlEntry
    {
        public override string GetHtml(HostHtmlEntryType entryType, string otherName = null)
            => entryType switch
            {
                HostHtmlEntryType.Css => "",
                HostHtmlEntryType.Js => "",
                HostHtmlEntryType.JsInterop => SessionJsInterop,
                _ => ""
            };

        private string SessionJsInterop =>
           $"<script src= \"_content/{Name}/LocalStorageJsInterop.js\"></script>"
            + $"<script src= \"_content/{Name}/SessionStorageJsInterop.js\"></script>"
            + $"<script src= \"_content/{Name}/MessageBoxJsInterop.js\"></script>"
            + $"<script src= \"_content/{Name}/ClipboardJsInterop.js\"></script>";

    }

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEifelMonoBlazorJavaScript(this IServiceCollection thisValue)
        {
            HostHtmlGlobals.RegisterEntry(new JavaScriptEntry());
            return thisValue;
        }
    }
}
