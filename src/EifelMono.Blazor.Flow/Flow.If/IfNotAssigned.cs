namespace EifelMono.Blazor.Flow
{
    public class IfNotAssigned : IfAssigned
    {
        protected override bool IsCondition() => !base.IsCondition();
    }
}
