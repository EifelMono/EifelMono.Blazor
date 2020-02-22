using System.Collections.Generic;

namespace EifelMono.Blazor.Bootstrap.Base
{
    public class AttributeBuilder : BaseBuilder<Dictionary<string, object>>
    {
        public Dictionary<string, object> ToDictionary()
            => Value ?? new AttributeBuilder();

        public static implicit operator Dictionary<string, object>(AttributeBuilder attributeBuilder)
            => attributeBuilder?.Value ?? new Dictionary<string, object>();

        protected override Dictionary<string, object> CreateValue()
            => new Dictionary<string, object>();

        public AttributeBuilder Empty(string key = "", object value = default)
        {
            Value.Clear();
            if (!string.IsNullOrEmpty(key))
                Value.Add(key, value);
            return this;
        }

        public AttributeBuilder New(string key = "", object value = default)
            => Empty(key, value);

        public AttributeBuilder Add(string key, object value = default)
        {
            Value.Add(key, value);
            return this;
        }


    }
}
