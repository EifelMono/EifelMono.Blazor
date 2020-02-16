using Microsoft.AspNetCore.Components;

namespace EifelMono.Blazor.Flow
{
    public class IfStringIsNullOrEmpty : Base.IfBase
    {
        protected override bool IsCondition() => string.IsNullOrEmpty(Value);

        [Parameter]
        public string Value { get; set; }
    }
}
