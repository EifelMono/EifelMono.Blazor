namespace EifelMono.Blazor.Flow.Base
{
    public static class IsDebugBuild
    {
        public static bool Value
            =>
#if DEBUG
                true;
#else
                false;
#endif
    }
}
