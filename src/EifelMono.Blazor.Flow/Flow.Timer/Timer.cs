using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace EifelMono.Blazor.Flow
{
    public class Timer : Base.TimerBase
    {
        public Timer()
          => Intervall = TimeSpan.FromSeconds(1);

        [Parameter]
        public new TimeSpan Intervall { get => base.Intervall; set => base.Intervall = value; }

        [Parameter]
        public RenderFragment<Base.ComponentContext<Timer>> ChildContent { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder?.AddContent(0, ChildContent(new Base.ComponentContext<Timer>(this)));
        }
    }
}
