using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EifelMono.Blazor.Flow
{
    public class ForEachContext<T>
    {
        public ForEachContext(T item, int index)
        {
            Item = item;
            Index = index;
        }
        public T Item { get; }
        public int Index { get; }
    }
}
