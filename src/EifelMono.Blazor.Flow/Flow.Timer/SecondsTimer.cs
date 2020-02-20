using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace EifelMono.Blazor.Flow
{
    public class SecondsTimer : Base.TimerBase
    {
        public SecondsTimer()
             => Intervall = TimeSpan.FromSeconds(1);

        [Parameter]
        public int Seconds
        {
            get => Intervall.Seconds;
            set => Intervall = TimeSpan.FromSeconds(value);
        }

        [Parameter]
        public RenderFragment<Base.ComponentContext<SecondsTimer>> ChildContent { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder?.AddContent(0, ChildContent(new Base.ComponentContext<SecondsTimer>(this)));
        }
    }
}
