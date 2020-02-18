namespace EifelMono.Blazor.Flow
{
    public class WhileContext
    {
        public WhileContext(Base.WhileBase @while, int index)
        {
            While = @while;
            Index = index;
        }

        private Base.WhileBase While { get; set; }

        public bool Break()
            => While.Break = true;
        public int Index { get; }

        public override string ToString()
            => $"Index={Index} Break={While.Break}";
    }
}
