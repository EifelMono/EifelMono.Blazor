using Microsoft.JSInterop;

namespace EifelMono.Blazor.Core
{
    public class HostHtmlInit
    {
        public static IJSRuntime JSRuntime { get; set; }
        public string Name { get; set; }
        public virtual string GetHtml(HostHtmlInitType initType, string userName = null)
            => "";
    }
}
