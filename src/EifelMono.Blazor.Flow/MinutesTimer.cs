using System;
using Microsoft.AspNetCore.Components;

namespace EifelMono.Blazor.Flow
{
    public class MinutesTimer : Base.TimerBase
    {
        public MinutesTimer()
            => Minutes = 1;
        protected int _minutes;
        [Parameter]
        public int Minutes
        {
            get => _minutes;
            set
            {
                base.Intervall = TimeSpan.FromMinutes(_minutes);
                _minutes = value;
            }
        }
    }
}
