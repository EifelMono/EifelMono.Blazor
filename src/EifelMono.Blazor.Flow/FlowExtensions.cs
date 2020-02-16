using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace EifelMono.Blazor.Flow
{
    public static class FlowExtensions
    {
        /// <summary>
        /// This Refresh only refreshs the component direct,
        /// but not all the children of this component. 
        /// It depends .....
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static T Refresh<T>(this T thisValue) where T : ComponentBase
        {
            if (thisValue is { })
                _ = thisValue.SetParametersAsync(ParameterView.Empty);
            return thisValue;
        }
    }
}
