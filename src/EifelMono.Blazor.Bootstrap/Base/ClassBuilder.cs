using System;

#pragma warning disable CA1062 // Validate arguments of public methods

namespace EifelMono.Blazor.Bootstrap.Base
{
    public class ClassBuilder : BaseBuilder<string>
    {
        public override string ToString()
            => Value ?? "";

        public static implicit operator string(ClassBuilder classBuilder)
            => classBuilder?.Value ?? "";

        protected override string CreateValue() => "";

        public ClassBuilder Empty(string @class = "")
        {
            Value = @class ?? "";
            return this;
        }

        public ClassBuilder New(string @class = "")
            => Empty(@class);

        public ClassBuilder Add(string @class)
        {
            Value += $" {@class ?? ""}";
            return this;
        }

        public ClassBuilder Add(string @class, bool when = true)
        {
            if (when)
                Add(@class);
            return this;
        }

        public ClassBuilder Add(string @class, Func<bool> when = null)
        {
            if ((when is { }) && when())
                Add(@class);
            return this;
        }

        public ClassBuilder Add(Func<string> @class, bool when = true)
        {
            if (@class is { } && when)
                Add(@class());
            return this;
        }

        public ClassBuilder Add(Func<string> @class, Func<bool> when = null)
        {
            if (@class is { } && when is { } && when())
                Add(@class());
            return this;
        }
    }
}
