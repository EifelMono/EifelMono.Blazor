using System;
using System.Linq;
using System.Collections.Generic;

#pragma warning disable CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).

namespace EifelMono.Blazor.Bootstrap
{
    public enum TextColor
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
        Muted,
        White
    }

    public static class TextColorExtensions
    {
        public static IEnumerable<TextColor> Values(this TextColor thisValue)
            => Enum.GetValues(typeof(TextColor)).Cast<TextColor>();

        public static string ToClassToColorOnly(this TextColor thisValue)
            => thisValue switch
            {
                TextColor.None => "",
                TextColor.Primary => "primary",
                TextColor.Secondary => "secondary",
                TextColor.Success => "success",
                TextColor.Danger => "danger",
                TextColor.Warning => "warning",
                TextColor.Info => "info",
                TextColor.Dark => "dark",
                TextColor.Muted => "muted",
                TextColor.White => "white",
            };

        public static string ToClassToRender(this TextColor thisValue)
        {
            var color = thisValue.ToClassToColorOnly();
            return string.IsNullOrEmpty(color) ? "" : $"text-{color}";
        }
    }
}
