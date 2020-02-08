namespace EifelMono.Blazor.Flow
{
    public class DebugBuild : If
    {
        protected override bool Condition() =>
#if DEBUG
            true;
#else
            false;
#endif
    }
}
