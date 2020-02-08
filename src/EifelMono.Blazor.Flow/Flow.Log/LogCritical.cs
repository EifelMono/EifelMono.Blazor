using Microsoft.Extensions.Logging;

namespace EifelMono.Blazor.Flow
{
    public class LogCritical : Base.LogBase
    {
        public LogCritical() : base() => LogLevel = LogLevel.Critical;
    }
}
