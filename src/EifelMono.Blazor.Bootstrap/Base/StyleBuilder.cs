#pragma warning disable CA1062 // Validate arguments of public methods

namespace EifelMono.Blazor.Bootstrap.Base
{
    public class StyleBuilder : BaseBuilder<string>
    {
        public override string ToString()
            => Value ?? "";

        public static implicit operator string(StyleBuilder styleBuilder)
            => styleBuilder?.Value ?? "";

        protected override string CreateValue() => "";

        public StyleBuilder Empty(string style = "")
        {
            Value = style ?? "";
            return this;
        }

        public StyleBuilder New(string style = "")
            => Empty(style);

    }
}
