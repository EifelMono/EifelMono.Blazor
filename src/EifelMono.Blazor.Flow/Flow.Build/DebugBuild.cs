namespace EifelMono.Blazor.Flow
{
    public class DebugBuild : If
    {
        protected override bool IsCondition() => Base.IsDebugBuild.Value;
    }
}
