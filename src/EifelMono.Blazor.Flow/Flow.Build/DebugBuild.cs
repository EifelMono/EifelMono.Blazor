namespace EifelMono.Blazor.Flow
{
    public class DebugBuild : Base.IfBase
    {
        protected override bool IsCondition() => FlowGlobals.IsDebug;
    }
}
