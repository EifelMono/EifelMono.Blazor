using System;
using System.Linq;
using System.Collections.Generic;

#pragma warning disable CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).

namespace EifelMono.Blazor.Bootstrap
{
    public enum ButtonColor
    {
        None,
        Primary,
        Secondary,
        Success,
        Danger,
        Warning,
        Info,
        Light,
        Dark,
        Link
    }

    public static class ButtonColorExtensions
    {
        public static IEnumerable<ButtonColor> Values(this ButtonColor thisValue)
            => Enum.GetValues(typeof(ButtonColor)).Cast<ButtonColor>();

        public static string ToClassToColorOnly(this ButtonColor thisValue)
           => thisValue switch
           {
               ButtonColor.None => "",
               ButtonColor.Primary => "primary",
               ButtonColor.Secondary => "secondary",
               ButtonColor.Success => "success",
               ButtonColor.Danger => "danger",
               ButtonColor.Warning => "warning",
               ButtonColor.Info => "info",
               ButtonColor.Light => "light",
               ButtonColor.Dark => "dark",
               ButtonColor.Link => "link",
           };

        public static string ToClassToRender(this ButtonColor thisValue, bool isOutline = false)
        {
            var color = thisValue.ToClassToColorOnly();
            return string.IsNullOrEmpty(color) ? "" : (isOutline ? $"btn-outlin-{color}" : $"btn-{color}");
        }
    }
}
