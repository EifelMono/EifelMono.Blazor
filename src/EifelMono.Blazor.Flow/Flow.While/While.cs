using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace EifelMono.Blazor.Flow
{
#pragma warning disable CA1716 // Identifiers should not match keywords
    public class While : Base.WhileBase
#pragma warning restore CA1716 // Identifiers should not match keywords
    {
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index = 0;
            while (Condition?.Invoke() ?? false)
            {
                if (Break)
                    break;
                builder?.AddContent(0, ChildContent(new WhileContext(this, index++)));
            }
        }
    }
}
