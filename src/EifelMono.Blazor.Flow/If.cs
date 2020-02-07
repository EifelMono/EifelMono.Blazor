using Microsoft.AspNetCore.Components;

namespace EifelMono.Blazor.Flow
{
    public class If : Base.IfBase
    {
        protected override bool Condition() => Value;

        [Parameter]
        public bool Value { get; set; }
    }
}
