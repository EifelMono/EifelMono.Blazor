using Microsoft.Extensions.Logging;

namespace EifelMono.Blazor.Flow
{
    public class LogTrace : Base.LogBase
    {
        public LogTrace() : base()
            => LogLevel = LogLevel.Trace;
    }
}
