namespace EifelMono.Blazor.Flow
{
    public class Debug : If
    {
        protected override bool Condition() =>
#if DEBUG
            true
#else
            false
#endif
            ;

    }
}
