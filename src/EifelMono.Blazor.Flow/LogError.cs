using Microsoft.Extensions.Logging;

namespace EifelMono.Blazor.Flow
{
    public class LogError : Base.LogBase
    {
        public LogError() : base()
            => LogLevel = LogLevel.Error;
    }
}
