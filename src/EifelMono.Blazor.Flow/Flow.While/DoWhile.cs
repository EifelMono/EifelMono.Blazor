using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace EifelMono.Blazor.Flow
{
#pragma warning disable CA1716 // Identifiers should not match keywords
    public class DoWhile<T> : ComponentBase
#pragma warning restore CA1716 // Identifiers should not match keywords
    {
        private bool _condition;
        [Parameter]
        public bool Condition { get => _condition; set => _condition = value; }
        [Parameter]
        public RenderFragment<WhileContext> ChildContent { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index = 0;
            while (Condition)
                builder?.AddContent(0, ChildContent(new WhileContext(ref _condition, index++)));
        }
    }
}
