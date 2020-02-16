namespace EifelMono.Blazor.Flow
{
    public class WhileContext
    {
        public WhileContext(ref bool item, int index)
        {
            Condition = item;
            Index = index;
        }
        public bool Condition { get; set; }
        public int Index { get; }
    }
}
