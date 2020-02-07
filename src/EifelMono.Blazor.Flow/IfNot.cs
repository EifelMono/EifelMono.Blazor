namespace EifelMono.Blazor.Flow
{
    public class IfNot : If
    {
        protected override bool Condition() => !base.Condition();
    }
}
