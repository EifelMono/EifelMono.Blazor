using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

#pragma warning disable CA1063 // Implement IDisposable Correctly
#pragma warning disable CA2007 // Consider calling ConfigureAwait on the awaited task
#pragma warning disable CA1031 // Do not catch general exception types
#pragma warning disable CA1816 // Dispose methods should call SuppressFinalize

namespace EifelMono.Blazor.Flow.Base
{
    public class TimerBase : ComponentBase, IDisposable
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public void Dispose()
        {
            try
            {
                if (_cancellationTokenSource is { })
                {
                    _cancellationTokenSource.Cancel();
                    _cancellationTokenSource.Dispose();
                    _cancellationTokenSource = null;
                }
            }
            catch { }
        }

        private CancellationTokenSource _cancellationTokenSource = null;

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
                _ = IntervallLoopAsync();
            return base.OnAfterRenderAsync(firstRender);
        }
        protected TimeSpan Intervall { get; set; } = TimeSpan.FromSeconds(1);

        private async Task IntervallLoopAsync()
        {
            if (_cancellationTokenSource is { })
                return;
            _cancellationTokenSource = new CancellationTokenSource();
            try
            {
                while (!_cancellationTokenSource.IsCancellationRequested)
                {
                    StateHasChanged();
                    await Task.Delay(Intervall, _cancellationTokenSource.Token);
                }
            }
            catch { }
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            builder?.AddContent(0, ChildContent);
        }
    }
}
