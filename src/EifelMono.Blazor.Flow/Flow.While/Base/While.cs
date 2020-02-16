using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace EifelMono.Blazor.Flow.Base
{
    public class WhileBase : ComponentBase
    {
        [Parameter]
        public bool Condition { get; set; }
        [Parameter]
        public RenderFragment<WhileContext> ChildContent { get; set; }

        public bool Break { get; set; }
    }
}
