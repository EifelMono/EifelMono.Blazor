using System;
using System.Linq;
using System.Collections.Generic;

#pragma warning disable CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).

namespace EifelMono.Blazor.Bootstrap
{
    public enum BgColor
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
        White
    }

    public static class BGColorExtensions
    {
        public static IEnumerable<BgColor> Values(this BgColor thisValue)
            => Enum.GetValues(typeof(BgColor)).Cast<BgColor>();

        public static string ToClassToColorOnly(this BgColor thisValue)
            => thisValue switch
            {
                BgColor.None => "",
                BgColor.Primary => "primary",
                BgColor.Secondary => "secondary",
                BgColor.Success => "success",
                BgColor.Danger => "danger",
                BgColor.Warning => "warning",
                BgColor.Info => "info",
                BgColor.Dark => "dark",
                BgColor.White => "white",
            };

        public static string ToClassToRender(this BgColor thisValue)
        {
            var color = thisValue.ToClassToColorOnly();
            return string.IsNullOrEmpty(color) ? "" : $"bg-{color}";
        }
    }
}
