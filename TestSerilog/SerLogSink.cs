using Serilog;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Formatting.Display;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSerilog
{
    public class SerLogSink : ILogEventSink
    {
        public EventHandler<LogEventHandlerArgs> OnMessageGenerated;
        private readonly IFormatProvider _formatProvider;
        readonly ITextFormatter _textFormatter = new MessageTemplateTextFormatter("{Timestamp} [{Level}] {Message}{Exception}",CultureInfo.CurrentCulture);

        public ConcurrentQueue<string> Events { get; } = new ConcurrentQueue<string>();

        public SerLogSink(IFormatProvider formatProvider)
        {
            _formatProvider = formatProvider;
        }
        
        public void Emit(LogEvent logEvent)
        {
            //var message = logEvent.RenderMessage(_formatProvider);
            //Console.WriteLine(DateTimeOffset.Now.ToString() + " " + message);

            

            var renderSpace = new StringWriter(CultureInfo.CurrentCulture);
            _textFormatter.Format(logEvent, renderSpace);

            var debug = renderSpace.ToString();

            Events.Enqueue(renderSpace.ToString());

            if(Events.Count > 3)
            {
                Events.TryDequeue(out var msg);
            }

            OnMessageGenerated?.Invoke(this, new LogEventHandlerArgs { Messages = Events.ToList() });
        }
    }

    public static class MySinkExtensions
    {
        public static LoggerConfiguration SerLogSink(
                  this LoggerSinkConfiguration loggerConfiguration,
                  IFormatProvider formatProvider = null)
        {
            return loggerConfiguration.Sink(new SerLogSink(formatProvider));
        }
    }

    public class LogEventHandlerArgs : EventArgs
    {
        public List<string> Messages { get; set; }
    }
}
