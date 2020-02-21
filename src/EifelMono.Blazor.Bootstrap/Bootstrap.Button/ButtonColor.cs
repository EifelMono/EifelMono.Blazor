using System;
using System.Linq;
using System.Collections.Generic;

namespace EifelMono.Blazor.Bootstrap
{
    public enum ButtonColor
    {
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

        public static string ClassToRender(this ButtonColor thisValue, bool isOutline = false)
            => thisValue switch
            {
                ButtonColor.Primary => isOutline ? "btn-outline-primary" : "btn-primary",
                ButtonColor.Secondary => isOutline ? "btn-outline-secondary" : "btn-secondary",
                ButtonColor.Success => isOutline ? "btn-outline-success" : "btn-success",
                ButtonColor.Danger => isOutline ? "btn-outline-danger" : "btn-danger",
                ButtonColor.Warning => isOutline ? "btn-outline-warning" : "btn-warning",
                ButtonColor.Info => isOutline ? "btn-outline-info" : "btn-info",
                ButtonColor.Dark => isOutline ? "btn-outline-dark" : "btn-dark",
                ButtonColor.Link => isOutline ? "btn-outline-link" : "btn-link",
                _ => isOutline ? "btn-outline-light" : "btn-light",
            };
    }
}
