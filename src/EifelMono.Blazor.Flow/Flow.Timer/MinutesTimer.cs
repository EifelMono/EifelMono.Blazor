using System;
using Microsoft.AspNetCore.Components;

namespace EifelMono.Blazor.Flow
{
    public class MinutesTimer : Base.TimerBase
    {
        public MinutesTimer()
            => Minutes = 1;

        [Parameter]
        public int Minutes
        {
            get => Intervall.Minutes;
            set => Intervall = TimeSpan.FromMinutes(value);
        }
    }
}
