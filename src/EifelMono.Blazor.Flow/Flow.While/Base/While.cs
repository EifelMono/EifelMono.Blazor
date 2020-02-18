using System;
using Microsoft.AspNetCore.Components;

namespace EifelMono.Blazor.Flow.Base
{
    public class WhileBase : ComponentBase
    {
        [Parameter]
        public Func<bool> Condition { get; set; } = () => false;
        [Parameter]
        public RenderFragment<WhileContext> ChildContent { get; set; }

        public bool Break { get; set; }
    }
}
