using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.JSInterop;

namespace EifelMono.Blazor.Core
{
    public static class HostHtmlGlobals
    {
        public static List<HostHtmlEntry> Entries { get; set; } = new List<HostHtmlEntry>();

        public static void RegisterEntry(HostHtmlEntry entry)
        {
            if (!(entry is { }))
                return;
            entry.Name = entry.GetType().Assembly.GetName().Name;
            if (Entries.FirstOrDefault(i => i.Name == entry.Name) is var item && item is null)
                Entries.Add(entry);
        }
    }
}
