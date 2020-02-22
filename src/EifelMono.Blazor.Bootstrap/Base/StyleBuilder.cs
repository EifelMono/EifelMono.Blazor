#pragma warning disable CA1062 // Validate arguments of public methods

using System;

namespace EifelMono.Blazor.Bootstrap.Base
{
    public class StyleBuilder : BaseBuilder<string>
    {
        public override string ToString()
            => Value ?? "";

        public static implicit operator string(StyleBuilder styleBuilder)
            => styleBuilder?.Value ?? "";

        protected override string CreateValue() => "";

        private StyleBuilder AddValue(string value)
        {
            if (!string.IsNullOrEmpty(value))
                Value += " " + value;
            return this;
        }

        public StyleBuilder Empty()
        {
            Value = "";
            return this;
        }
        public StyleBuilder AddStyle(string style, bool when = true)
            => when ? AddValue(style) : this;

        public StyleBuilder Empty(string name, string value, bool when = true)
        {
            Empty();
            if (!(string.IsNullOrEmpty(name) && string.IsNullOrEmpty(name) && when))
                AddValue($"{name}:{value};");
            return this;
        }

        public StyleBuilder Add(string name, string value)
        {
            if (!(string.IsNullOrEmpty(name) && string.IsNullOrEmpty(name)))
                AddValue($"{name}:{value};");
            return this;
        }
        public StyleBuilder Add(string name, string value, bool when)
        {
            if (!(string.IsNullOrEmpty(name) && string.IsNullOrEmpty(name) && when))
                AddValue($"{name}:{value};");
            return this;
        }
        public StyleBuilder Add(string name, string value, Func<bool> when)
        {
            if (!(string.IsNullOrEmpty(name) && string.IsNullOrEmpty(name) && when is { } && when()))
                AddValue($"{name}:{value};");
            return this;
        }
    }
}
