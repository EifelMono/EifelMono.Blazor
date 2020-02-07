using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace EifelMono.Blazor.Flow.Base
{
    public class IfBase : ComponentBase
    {
        [Parameter]
        public RenderFragment Then { get; set; } = null;

        [Parameter]
        public RenderFragment Else { get; set; } = null;

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected virtual bool Condition() => false;
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            if (Then is { } || Else is { })
            {
                builder.AddContent(0, Condition() ? Then : Else);
            }
            else
            {
                if (Condition())
                    builder.AddContent(2, ChildContent);
            }
        }
    }
}
