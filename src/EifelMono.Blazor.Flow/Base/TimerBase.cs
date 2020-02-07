using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

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
                if (CancellationTokenSource is { })
                {
                    CancellationTokenSource.Cancel();
                    CancellationTokenSource = null;
                }
            }
            catch { }
        }

        private CancellationTokenSource CancellationTokenSource = null;

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
                IntervallLoop();
            return base.OnAfterRenderAsync(firstRender);
        }
        protected TimeSpan Intervall { get; set; } = TimeSpan.FromSeconds(1);

        private async void IntervallLoop()
        {
            if (CancellationTokenSource is { })
                return;
            CancellationTokenSource = new CancellationTokenSource();
            try
            {
                while (!CancellationTokenSource.IsCancellationRequested)
                {
                    this.StateHasChanged();
                    await Task.Delay(Intervall, CancellationTokenSource.Token);
                }
            }
            catch { }
            finally
            {
                CancellationTokenSource = null;
            }
        }
        
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            builder.AddContent(0, ChildContent);
        }
    }
}
