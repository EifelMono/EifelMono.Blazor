using Microsoft.AspNetCore.Components;

namespace EifelMono.Blazor.Flow
{
    public static class FlowExtensions
    {
        /// <summary>
        /// This Redraw only redraws the component direct,
        /// but not all the children of this component. 
        /// It depends .....
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static T RedrawChild<T>(this T thisValue) where T : ComponentBase
        {
#pragma warning disable CA1062 // Validate arguments of public methods
            if (thisValue is { })
                _ = thisValue.SetParametersAsync(ParameterView.Empty);
            return thisValue;
#pragma warning restore CA1062 // Validate arguments of public methods
        }
    }
}
