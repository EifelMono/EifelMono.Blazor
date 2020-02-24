using Microsoft.AspNetCore.Components;
namespace EifelMono.Blazor.JavaScript.Base
{
    public class ComponentContext<T> where T : ComponentBase
    {
        public ComponentContext(T @component)
            => Component = @component;
        public T Component { get; set; }
    }
}
