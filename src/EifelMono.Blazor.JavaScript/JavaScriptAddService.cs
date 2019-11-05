using EifelMono.Blazor.Core;
using Microsoft.Extensions.DependencyInjection;

namespace EifelMono.Blazor.JavaScript
{
    internal class Init : HostHtmlInit
    {
        public override string GetHtml(HostHtmlInitType initType, string userName = null)
            => initType switch
            {
                HostHtmlInitType.Css => "",
                HostHtmlInitType.Js => "",
                HostHtmlInitType.JsInterop => SessionJsInterop,
                _ => ""
            };

        private string SessionJsInterop =>
           $"<script src= \"_content/{Name}/SessionJsInterop.js\"></script>";
    }

    public static class JavaScriptAddService
    {
        public static IServiceCollection AddEifelMonoBlazorJavaScript(this IServiceCollection thisValue)

        {
            HostHtmlInits.Instance.AddInit(new Init());
            return thisValue;
        }
    }
}
