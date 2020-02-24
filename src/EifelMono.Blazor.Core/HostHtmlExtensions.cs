using System;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.JSInterop;
#pragma warning disable IDE0060 // Remove unused parameter

namespace EifelMono.Blazor.Core
{
    public static class HostHtmlExtensions
    {
        private static Func<HostHtmlEntryType, string, string> onHostHtmlUser;

        public static Func<HostHtmlEntryType, string, string> GetOnHostHtmlUser()
            => onHostHtmlUser;

        public static void SetOnBlazorHtml(Func<HostHtmlEntryType, string, string> value)
            => onHostHtmlUser = value;

        internal static IHtmlContent EifelMonoHostHtmlUseType<T>(this IHtmlHelper<T> thisValue, HostHtmlEntryType entryType, string otherName = null)
        {
            var sb = new StringBuilder();
            if (entryType == HostHtmlEntryType.Other && !string.IsNullOrEmpty(otherName))
            {
                sb.AppendLine($"<!-- BlazorHtmlUse {entryType} {otherName ?? ""} -->");
                if (GetOnHostHtmlUser() is { })
                    foreach (var item in HostHtmlGlobals.Entries)
                        sb.AppendLine(GetOnHostHtmlUser()(entryType, otherName));
            }
            else
            {
                sb.AppendLine($"<!-- BlazorHtmlUse {entryType} -->");
                foreach (var item in HostHtmlGlobals.Entries)
                    sb.AppendLine(item.GetHtml(entryType));
            }
            return new HtmlString(sb.ToString());
        }

        public static IHtmlContent EifelMonoHostHtmlUseCss<T>(this IHtmlHelper<T> thisValue)
            => thisValue.EifelMonoHostHtmlUseType<T>(HostHtmlEntryType.Css);
        public static IHtmlContent EifelMonoHostHtmlUseJs<T>(this IHtmlHelper<T> thisValue)
            => thisValue.EifelMonoHostHtmlUseType<T>(HostHtmlEntryType.Js);
        public static IHtmlContent EifelMonoHostHtmlUseJsInterop<T>(this IHtmlHelper<T> thisValue)
            => thisValue.EifelMonoHostHtmlUseType<T>(HostHtmlEntryType.JsInterop);
        public static IHtmlContent EifelMonoHostHtmlUseUser<T>(this IHtmlHelper<T> thisValue, string otherName)
            => thisValue.EifelMonoHostHtmlUseType<T>(HostHtmlEntryType.Other, otherName);
    }
}
