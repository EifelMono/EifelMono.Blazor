using System;
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
            get => (_category ?? (_category = GetType().Namespace));
            set
            {
                _category = value;
                Logger = null;
            }
        }

        [Parameter]
        public Func<string> Message { get; set; }

        [Inject]
        public ILoggerFactory LoggerFactory { get; set; }
        protected ILogger Logger { get; set; }

        protected LogLevel LogLevel { get; set; } = LogLevel.Trace;

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (!(Logger is { }))
                Logger = LoggerFactory.CreateLogger(Category);
            var message = Message?.Invoke() ?? "";
            Logger.Log(LogLevel, message);
        }
    }
}
