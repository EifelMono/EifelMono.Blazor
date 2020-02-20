using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace EifelMono.Blazor.Flow
{
    public class ForEach<T> : ComponentBase
    {
        [Parameter]
        public IReadOnlyList<T> Items { get; set; }
        [Parameter]
        public RenderFragment<ForEachContext<T>> ChildContent { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var index = 0;
            foreach (var item in Items)
                builder?.AddContent(0, ChildContent(new ForEachContext<T>(this, item, index++)));
        }
    }
}
