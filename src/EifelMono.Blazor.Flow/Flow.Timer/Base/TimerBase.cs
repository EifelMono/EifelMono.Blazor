using System;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.Components;

#pragma warning disable CA1063 // Implement IDisposable Correctly
#pragma warning disable CA2007 // Consider calling ConfigureAwait on the awaited task
#pragma warning disable CA1031 // Do not catch general exception types
#pragma warning disable CA1816 // Dispose methods should call SuppressFinalize
#pragma warning disable CA2213
#pragma warning disable CA1822

namespace EifelMono.Blazor.Flow.Base
{
    public class TimerBase : ComponentBase, IDisposable
    {
        private bool _enabled = true;
        [Parameter]
        public bool Enabled
        {
            get => _enabled;
            set
            {
                var changed = _enabled != value;
                _enabled = value;
                if (changed)
                    SystemTimerChanged();
            }
        }

        private bool _autoReset = true;
        [Parameter]
        public bool AutoReset
        {
            get => _autoReset;
            set
            {
                var changed = _autoReset != value;
                _autoReset = value;
                if (changed)
                    SystemTimerChanged();
            }
        }

        private TimeSpan _intervall;
        protected TimeSpan Intervall
        {
            get => _intervall;
            set
            {
                var changed = _intervall.Ticks != value.Ticks;
                _intervall = value;
                if (changed)
                    SystemTimerChanged();
            }
        }

        protected bool IsRendered { get; set; } = false;
        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                IsRendered = true;
                SystemTimerChanged();
            }
            return base.OnAfterRenderAsync(firstRender);
        }

        public void Dispose()
        {
            try
            {
                if (_systemTimer is { })
                {
                    _systemTimer.Elapsed -= ProcessTimerElapsed;
                    _systemTimer.Dispose();
                }
                _systemTimer = null;
            }
            catch { }
        }

        private System.Timers.Timer _systemTimer = null;
        protected System.Timers.Timer SystemTimer
        {
            get
            {
                if (!(_systemTimer is { }))
                {
                    _systemTimer = new System.Timers.Timer();
                    _systemTimer.Elapsed += ProcessTimerElapsed;
                }
                return _systemTimer;
            }
            set
            {
                _systemTimer = value;
            }
        }

        private void ProcessTimerElapsed(object source, ElapsedEventArgs e)
            => InvokeAsync(StateHasChanged);


        protected void SystemTimerChanged()
        {
            if (!IsRendered)
                return;
            SystemTimer.Stop();
            if (Enabled)
            {
                SystemTimer.Enabled = true;
                SystemTimer.AutoReset = AutoReset;
                SystemTimer.Interval = Intervall.TotalMilliseconds;
                SystemTimer.Start();
            }
        }
    }
}
