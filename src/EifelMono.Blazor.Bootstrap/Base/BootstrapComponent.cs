using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace EifelMono.Blazor.Bootstrap.Base
{
    public class BootstrapComponent : ComponentBase
    {

        [Parameter]
        public string Class { get; set; }
        protected ClassBuilder ClassToRender { get; } = new ClassBuilder();

        [Parameter]
        public string Style { get; set; }
        protected StyleBuilder StyleToRender { get; } = new StyleBuilder();

        protected AttributeBuilder AttributesToRender { get; } = new AttributeBuilder();
    }
}
