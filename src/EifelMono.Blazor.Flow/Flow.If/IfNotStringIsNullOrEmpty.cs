namespace EifelMono.Blazor.Flow
{
    public class IfNotStringIsNullOrEmpty : IfStringIsNullOrEmpty
    {
        protected override bool Condition() => !base.Condition();
    }
}
