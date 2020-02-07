namespace EifelMono.Blazor.Flow
{
    public class IfNotAssigned : IfAssigned
    {
        protected override bool Condition() => !base.Condition();
    }
}
