using System.Threading.Tasks;

namespace EifelMono.Blazor.JavaScript
{
    public class MessageBox
    {
        // www/Storage/MessageBoxJSInterop.js
        private static readonly string s_jSPrefix = "EifelMonoBlazorJavaScriptMessageBoxJSInterop";

        public static ValueTask<object> ShowAsync(string text)
            => Core.HostHtmlInit.JSRuntime.InvokeAsync<object>($"{s_jSPrefix}.Show", new[] { text });
    }
}
