using System;
using System.Linq;
using System.Collections.Generic;

#pragma warning disable CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).

namespace EifelMono.Blazor.Bootstrap
{
    public enum BackgroundColor
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

    public static class BackgroundColorExtensions
    {
        public static IEnumerable<BackgroundColor> Values(this BackgroundColor thisValue)
            => Enum.GetValues(typeof(BackgroundColor)).Cast<BackgroundColor>();

        public static string ToClassToColorOnly(this BackgroundColor thisValue)
            => thisValue switch
            {
                BackgroundColor.None => "",
                BackgroundColor.Primary => "primary",
                BackgroundColor.Secondary => "secondary",
                BackgroundColor.Success => "success",
                BackgroundColor.Danger => "danger",
                BackgroundColor.Warning => "warning",
                BackgroundColor.Info => "info",
                BackgroundColor.Dark => "dark",
                BackgroundColor.White => "white",
            };

        public static string ToClassToRender(this BackgroundColor thisValue)
        {
            var color = thisValue.ToClassToColorOnly();
            return string.IsNullOrEmpty(color) ? "" : $"bg-{color}";
        }
    }
}
