namespace EifelMono.Blazor.Flow
{
    public class ForEachContext<T>: Base.ComponentContext<ForEach<T>>
    {
        public ForEachContext(ForEach<T> component, T item, int index): base(component)
        {
            Item = item;
            Index = index;
        }
        public T Item { get; }
        public int Index { get; }
    }
}
