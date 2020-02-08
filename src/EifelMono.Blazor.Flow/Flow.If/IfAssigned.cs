using Microsoft.AspNetCore.Components;

namespace EifelMono.Blazor.Flow
{
    public class IfAssigned : Base.IfBase
    {
        protected override bool Condition() => Value is { };

        [Parameter]
        public object Value { get; set; }
    }
}
