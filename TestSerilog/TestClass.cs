using Serilog;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSerilog
{
    public class TestClass
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public int Alter { get; set; }
        public string Email { get; set; }

        private ILogger _myLogger;

        public TestClass()
        {
            _myLogger = Log.ForContext<TestClass>();
            _myLogger.Information("Hello, I am in the constructor");
        }

        public override string ToString()
        {
            using (LogContext.PushProperty("Mail", Email))
            {
                _myLogger.Information("ToString():");
            }
            return $"{Vorname}, {Nachname}: {Alter} alt";
        }
    }
}
