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

        protected virtual bool IsCondition() => false;
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (Then is { } || Else is { })
            {
                builder?.AddContent(0, IsCondition() ? Then : Else);
            }
            else
            {
                if (IsCondition())
                    builder?.AddContent(0, ChildContent);
            }
        }
    }
}
