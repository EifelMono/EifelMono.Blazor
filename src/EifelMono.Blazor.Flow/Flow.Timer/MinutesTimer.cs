using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace EifelMono.Blazor.Flow
{
    public class MinutesTimer : Base.TimerBase
    {
        public MinutesTimer()
            => Intervall= TimeSpan.FromMinutes(1);

        [Parameter]
        public int Minutes
        {
            get => Intervall.Minutes;
            set => Intervall = TimeSpan.FromMinutes(value);
        }

        [Parameter]
        public RenderFragment<Base.ComponentContext<MinutesTimer>> ChildContent { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder?.AddContent(0, ChildContent(new Base.ComponentContext<MinutesTimer>(this)));
        }
    }
}
