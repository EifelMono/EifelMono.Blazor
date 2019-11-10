using System.Threading.Tasks;

namespace EifelMono.Blazor.JavaScript
{
    public class Clipboard
    {
        // www/Storage/ClipBoardJSInterop.js
        private static readonly string s_jSPrefix = "EifelMonoBlazorJavaScriptClipboardJSInterop";

        // do es not work PREMISSION!!!!
        public static ValueTask<object> WriteTextAsync(string text)
            => Core.HostHtmlInit.JSRuntime.InvokeAsync<object>($"{s_jSPrefix}.WriteText", new[] { text });
    }
}
