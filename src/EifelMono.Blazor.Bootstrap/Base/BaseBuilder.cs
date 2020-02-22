namespace EifelMono.Blazor.Bootstrap.Base
{
    public abstract class BaseBuilder<T>
    {
        private T _value;
        public T Value
        {
            get => _value ?? (_value = CreateValue());
            set => _value = value;
        }

        protected abstract T CreateValue();
    }
}
