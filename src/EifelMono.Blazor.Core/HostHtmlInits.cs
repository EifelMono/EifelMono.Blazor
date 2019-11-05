using System.Collections.Generic;
using System.Linq;

namespace EifelMono.Blazor.Core
{
    public class HostHtmlInits
    {
        private static HostHtmlInits s_instance = null;
        public static HostHtmlInits Instance { get => s_instance ?? (s_instance = new HostHtmlInits()); }
        public List<HostHtmlInit> Items { get; set; } = new List<HostHtmlInit>();

        public void AddInit(HostHtmlInit init)
        {
            if (!(init is { }))
                return;
            init.Name = init.GetType().Assembly.GetName().Name;
            if (Items.FirstOrDefault(i => i.Name == init.Name) is var item && item is null)
                Items.Add(init);
        }
    }
}
