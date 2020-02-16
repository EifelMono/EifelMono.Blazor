using Microsoft.AspNetCore.Components;

namespace EifelMono.Blazor.Flow
{
    public class IfAssigned : Base.IfBase
    {
        protected override bool IsCondition() => Value is { };

        [Parameter]
        public object Value { get; set; }
    }
}
