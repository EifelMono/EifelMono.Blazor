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
        private static Func<HostHtmlInitType, string, string> onHostHtmlUser;

        public static Func<HostHtmlInitType, string, string> GetOnHostHtmlUser()
        {
            return onHostHtmlUser;
        }

        public static void SetOnBlazorHtml(Func<HostHtmlInitType, string, string> value)
        {
            onHostHtmlUser = value;
        }

        internal static IHtmlContent BlazorComponentsCustom<T>(this IHtmlHelper<T> thisValue, HostHtmlInitType initType, string userName = null)
        {
            var sb = new StringBuilder();
            if (initType == HostHtmlInitType.User && !string.IsNullOrEmpty(userName))
            {
                sb.AppendLine($"<!-- BlazorHtmlInit {initType.ToString()} {userName ?? ""} -->");
                if (GetOnHostHtmlUser() is { })
                    foreach (var item in HostHtmlInits.Instance.Items)
                        sb.AppendLine(GetOnHostHtmlUser()(initType, userName));
            }
            else
            {
                sb.AppendLine($"<!-- BlazorHtmlInit {initType.ToString()} -->");
                foreach (var item in HostHtmlInits.Instance.Items)
                {
                    var html = item.GetHtml(initType, userName);
                    if (GetOnHostHtmlUser() is { })
                        html = GetOnHostHtmlUser()(initType, userName);
                    sb.AppendLine(item.GetHtml(initType));
                }
            }
            return new HtmlString(sb.ToString());
        }

        public static IHtmlContent EifelMonoHostHtmlInit<T>(this IHtmlHelper<T> thisValue, IJSRuntime jSRuntime)
        {
            HostHtmlInit.JSRuntime = jSRuntime;
            return new HtmlString("");
        }

        public static void EifelMonoMainLayoutInit(this ComponentBase thisValue, IJSRuntime jSRuntime)
        {
            HostHtmlInit.JSRuntime = jSRuntime;
        }

        public static IHtmlContent EifelMonoHostHtmlInitCss<T>(this IHtmlHelper<T> thisValue)
            => thisValue.BlazorComponentsCustom<T>(HostHtmlInitType.Css);
        public static IHtmlContent EifelMonoHostHtmlInitJs<T>(this IHtmlHelper<T> thisValue)
            => thisValue.BlazorComponentsCustom<T>(HostHtmlInitType.Js);
        public static IHtmlContent EifelMonoHostHtmlInitJsInterop<T>(this IHtmlHelper<T> thisValue)
            => thisValue.BlazorComponentsCustom<T>(HostHtmlInitType.JsInterop);
        public static IHtmlContent EifelMonoHostHtmlInitUser<T>(this IHtmlHelper<T> thisValue, string userName)
            => thisValue.BlazorComponentsCustom<T>(HostHtmlInitType.User, userName);
    }
}
