using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;

namespace EifelMono.Blazor.Flow
{
    public class IfAny<T> : Base.IfBase
    {
        protected override bool IsCondition() => Value.Any();

        [Parameter]
        public IEnumerable<T> Value { get; set; }
    }
}
