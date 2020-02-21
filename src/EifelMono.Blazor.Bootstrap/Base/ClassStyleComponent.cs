using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Components;

namespace EifelMono.Blazor.Bootstrap.Base
{
    public class ClassStyleComponent : ComponentBase
    {

        [Parameter]
        public string Class { get; set; }
        protected string ClassToRender { get; set; }

        [Parameter]
        public string Style { get; set; }
        protected string StyleToRender { get; set; }

        protected Dictionary<string, object> AttributesToRender { get; } = new Dictionary<string, object>();
    }
}
