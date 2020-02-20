using Microsoft.AspNetCore.Components;

namespace EifelMono.Blazor.Flow
{
#pragma warning disable CA1716 // Identifiers should not match keywords
    public class If : Base.IfBase
#pragma warning restore CA1716 // Identifiers should not match keywords
    {
        protected override bool IsCondition() => Value;

        [Parameter]
        public bool Value { get; set; }
    }
}
