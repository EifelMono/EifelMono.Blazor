using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

#pragma warning disable CA1822

namespace EifelMono.Blazor.Flow
{
    public class FlowSetGlobals : ComponentBase
    {
        [Parameter]
        public bool ShowFlowErrors { get => FlowGlobals.ShowFlowErrors; set => FlowGlobals.ShowFlowErrors = value; }
        [Parameter]
        public bool ShowConsoleOutput { get => FlowGlobals.ShowConsoleOutput; set => FlowGlobals.ShowConsoleOutput = value; }
        [Parameter]
        public RenderFragment<Base.ComponentContext<FlowSetGlobals>> ChildContent { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (ChildContent is { })
                builder?.AddContent(0, ChildContent(new Base.ComponentContext<FlowSetGlobals>(this)));
        }
    }
}
