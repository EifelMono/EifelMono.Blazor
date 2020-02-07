using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace EifelMono.Blazor.Flow
{
    public class Log : Base.LogBase
    {
        [Parameter]
        public new LogLevel LogLevel { get => base.LogLevel; set => base.LogLevel = value; }
    }
}
