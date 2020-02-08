namespace EifelMono.Blazor.Flow
{
    public class ReleaseBuild : DebugBuild
    {
        protected override bool Condition() => !base.Condition();
    }
}
