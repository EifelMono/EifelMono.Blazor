using Microsoft.AspNetCore.Components;

namespace EifelMono.Blazor.Flow
{
    public class IfStringIsNullOrEmpty : Base.IfBase
    {
        protected override bool Condition() => string.IsNullOrEmpty(Value);

        [Parameter]
        public string Value { get; set; }
    }
}
