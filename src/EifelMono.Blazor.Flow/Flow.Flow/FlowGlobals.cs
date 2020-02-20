namespace EifelMono.Blazor.Flow
{
    public static class FlowGlobals
    {
        public static bool IsDebug
            =>
#if DEBUG
                true;
#else
                false;
#endif

        public static bool ShowFlowErrors { get; set; } = true;

        public static bool ShowConsoleOutput { get; set; } = true;

    }
}
