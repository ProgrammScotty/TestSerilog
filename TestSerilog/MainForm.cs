using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Exceptions;

namespace TestSerilog
{
    public partial class MainForm : Form
    {
        private TestClass _testClass;
        private bool _isDebug;
        private LoggingLevelSwitch _levelSwitch;
        private SerLogSink _serLogSink;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _serLogSink = new SerLogSink(null);
            _serLogSink.OnMessageGenerated += OnReceiveMessageReceived;

            _levelSwitch = new LoggingLevelSwitch();
            _levelSwitch.MinimumLevel = LogEventLevel.Debug;

            Log.Logger = new LoggerConfiguration()
                .Destructure.ByTransforming<TestClass>(
                    r => new { VN = r.Vorname, NN = r.Nachname })
                .Enrich.WithThreadId().Enrich.WithThreadName().Enrich.WithExceptionDetails()
                .Enrich.FromLogContext()
                //.MinimumLevel.Debug()
                .MinimumLevel.ControlledBy(_levelSwitch)
                .WriteTo.File("logs\\TestSerilog.log", 
                    rollingInterval: RollingInterval.Day,
                    shared: true,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}]<{ThreadId}><{ThreadName}>{SourceContext} {Message} {Properties} {NewLine}{Exception} {ExceptionDetails}")
                .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information, 
                    outputTemplate: "{Message}{NewLine}{Exception} {ExceptionDetails}")
                //.WriteTo.Debug()
                .WriteTo.Sink(_serLogSink)
                .CreateLogger();

            _isDebug = Log.IsEnabled(LogEventLevel.Debug);
            if (_isDebug) Log.Debug("Someone is stuck debugging...");

            _levelSwitch.MinimumLevel = LogEventLevel.Verbose;
            Log.Verbose("This verbose message will now be logged");

            _testClass = new TestClass { Vorname = "Ströwa", Nachname = "Elch", Alter = 5, Email = "elch@guinnein.eu" };
            Log.Information("Testklasse erzeugt: {@TestClass}", _testClass);

            var strg = _testClass.ToString();
        }

        private void OnReceiveMessageReceived(object sender, LogEventHandlerArgs args)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var msg in args.Messages)
            {
                sb.AppendLine(msg);
            }

            tbx_LogMessage.InvokeIfRequired(() => tbx_LogMessage.Text = sb.ToString());
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {

        }

        private void btn_Crash_Click(object sender, EventArgs e)
        {
            var nix = 0;
            try
            {
                var crash = 1 / nix;
            }
            catch (DivideByZeroException ex)
            {
                Log.Error(ex, "");
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs events)
        {
            _serLogSink.OnMessageGenerated -= OnReceiveMessageReceived;
            Log.CloseAndFlush();

            events.Cancel = false;
        }


    }
}
