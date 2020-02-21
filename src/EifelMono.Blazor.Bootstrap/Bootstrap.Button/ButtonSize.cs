using System;
using System.Linq;
using System.Collections.Generic;

namespace EifelMono.Blazor.Bootstrap
{
    public enum ButtonSize
    {
        Small,
        Normal,
        Large,
    }

    public static class ButtonSizeExtensions
    {
        public static IEnumerable<ButtonSize> Values(this ButtonSize thisValue)
            => Enum.GetValues(typeof(ButtonSize)).Cast<ButtonSize>();

        public static string ClassToRender(this ButtonSize thisValue)
            => thisValue switch
            {
                ButtonSize.Small => "btn-sm",
                ButtonSize.Normal => "",
                ButtonSize.Large => "btn-lg",
                _ => "",
            };
    }
}
