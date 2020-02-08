using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;

namespace EifelMono.Blazor.Flow
{
    public class IfAny<T> : Base.IfBase
    {
        protected override bool Condition() => Value.Any();

        [Parameter]
        public IEnumerable<T> Value { get; set; }
    }
}
