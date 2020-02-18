using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace EifelMono.Blazor.Flow
{
    public class DoWhile<T> : Base.WhileBase
    {
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index = 0;
            do
            {
                if (Break)
                    break;
                builder?.AddContent(0, ChildContent(new WhileContext(this, index++)));
            } while (Condition?.Invoke() ?? false);
        }
    }
}
