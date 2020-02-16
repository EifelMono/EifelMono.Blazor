namespace EifelMono.Blazor.Flow
{
    public class ReleaseBuild : DebugBuild
    {
        protected override bool IsCondition() => !base.IsCondition();
    }
}
