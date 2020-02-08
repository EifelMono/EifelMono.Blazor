using Microsoft.Extensions.Logging;

namespace EifelMono.Blazor.Flow
{
    public class LogDebug : Base.LogBase
    {
        public LogDebug() : base()
            => LogLevel = LogLevel.Debug;
    }
}
