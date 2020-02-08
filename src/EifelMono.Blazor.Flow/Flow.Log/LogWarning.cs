using Microsoft.Extensions.Logging;

namespace EifelMono.Blazor.Flow
{
    public class LogWarning : Base.LogBase
    {
        public LogWarning() : base()
            => LogLevel = LogLevel.Warning;
    }
}
