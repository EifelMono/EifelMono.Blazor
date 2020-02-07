using Microsoft.Extensions.Logging;

namespace EifelMono.Blazor.Flow
{
    public class LogInformation : Base.LogBase
    {
        public LogInformation() : base()
            => LogLevel = LogLevel.Information;
    }
}
