using System;
using Microsoft.AspNetCore.Components;

namespace EifelMono.Blazor.Flow
{
    public class SecondsTimer : Base.TimerBase
    {
        public SecondsTimer()
            => Seconds = 1;

        [Parameter]
        public int Seconds
        {
            get => Intervall.Seconds;
            set => Intervall = TimeSpan.FromSeconds(value);
        }
    }
}
