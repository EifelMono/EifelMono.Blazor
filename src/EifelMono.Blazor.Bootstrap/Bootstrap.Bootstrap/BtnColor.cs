using System;
using System.Linq;
using System.Collections.Generic;

#pragma warning disable CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).

namespace EifelMono.Blazor.Bootstrap
{
    public enum BtnColor
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

    public static class BtnColorExtensions
    {
        public static IEnumerable<BtnColor> Values(this BtnColor thisValue)
            => Enum.GetValues(typeof(BtnColor)).Cast<BtnColor>();

        public static string ToClassToColorOnly(this BtnColor thisValue)
           => thisValue switch
           {
               BtnColor.None => "",
               BtnColor.Primary => "primary",
               BtnColor.Secondary => "secondary",
               BtnColor.Success => "success",
               BtnColor.Danger => "danger",
               BtnColor.Warning => "warning",
               BtnColor.Info => "info",
               BtnColor.Dark => "dark",
               BtnColor.Link => "link",
           };

        public static string ToClassToRender(this BtnColor thisValue, bool isOutline = false)
        {
            var color = thisValue.ToClassToColorOnly();
            return string.IsNullOrEmpty(color) ? "" : (isOutline ? $"btn-outlin-{color}" : $"btn-{color}");
        }
    }
}
