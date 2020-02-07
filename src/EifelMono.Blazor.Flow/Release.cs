namespace EifelMono.Blazor.Flow
{
    public class Release : Debug
    {
        protected override bool Condition() => !base.Condition();
    }
}
