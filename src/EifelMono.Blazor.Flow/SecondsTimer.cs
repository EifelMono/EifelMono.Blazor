using System;
using Microsoft.AspNetCore.Components;

namespace EifelMono.Blazor.Flow
{
    public class SecondsTimer : Base.TimerBase
    {
        public SecondsTimer()
            => Seconds = 1;

        protected int _seconds;
        [Parameter]
        public int Seconds
        {
            get => _seconds;
            set
            {
                base.Intervall = TimeSpan.FromSeconds(_seconds);
                _seconds = value;
            }
        }
    }
}
