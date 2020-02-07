using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.Extensions.Logging;

namespace EifelMono.Blazor.Flow.Base
{
    public class LogBase : ComponentBase
    {
        private string _category;
        [Parameter]
        public string Category
        {
            get => (_category ?? (_category = this.GetType().Namespace));
            set
            {
                _category = value;
                _logger = null;
            }
        }

        [Parameter]
        public string Message { get; set; }

        [Inject]
        public ILoggerFactory LoggerFactory { get; set; }
        protected ILogger _logger;

        protected LogLevel LogLevel { get; set; } = LogLevel.Trace;

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            if (!(_logger is { }))
                _logger = LoggerFactory.CreateLogger(Category);
            _logger.Log(LogLevel, Message);
        }
    }
}
