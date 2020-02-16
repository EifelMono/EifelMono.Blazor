namespace EifelMono.Blazor.Flow
{
    public class IfNot : If
    {
        protected override bool IsCondition() => !base.IsCondition();
    }
}
