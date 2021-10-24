using Serilog;
using System;
using System.Diagnostics;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.LiterateConsole()
                .CreateLogger();

            Trace.CorrelationManager.ActivityId = Guid.NewGuid();
            Trace.AutoFlush = true;
            var serilogTraceListener = new SerilogTraceListener.SerilogTraceListener();
            Trace.Listeners.Add(serilogTraceListener);
            Trace.WriteLine("A string written using Trace.WriteLine");

            var source = new TraceSource("Test");
            source.Switch.Level = SourceLevels.All;  //TODO:KS It needs this...
            source.Listeners.Add(serilogTraceListener); //TODO:KS It needs this...
            source.TraceEvent(TraceEventType.Information, 1001, "os={0}", Environment.OSVersion);

            Console.ReadLine();
        }

    }
}
