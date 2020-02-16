using System;
using Microsoft.AspNetCore.Components;

namespace EifelMono.Blazor.Flow
{
    public class Timer : Base.TimerBase
    {
        public Timer()
          => Intervall = TimeSpan.FromSeconds(1);

        [Parameter]
        public new TimeSpan Intervall { get => base.Intervall; set => base.Intervall = value; }

    }
}
