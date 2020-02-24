using Microsoft.JSInterop;

namespace EifelMono.Blazor.Core
{
    public class HostHtmlEntry
    {
        public string Name { get; set; }
        public virtual string GetHtml(HostHtmlEntryType entryType, string otherName = null)
            => "";
    }
}
