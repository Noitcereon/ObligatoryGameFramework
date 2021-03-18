using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DTurnBasedGameFramework.Configuration;
using _2DTurnBasedGameFramework.Helpers;

namespace _2DTurnBasedGameFramework
{
    public static class Logger
    {
        private static TraceSource _tracer;

        /// <summary>
        /// Instantiates a TraceSource and creates and adds listeners to the it.
        /// See Configuration.xml to change the level at which to log.
        /// </summary>
        private static TraceSource InitialiseTraceListener()
        {
            TraceSource theTraceSource = new TraceSource("2DTurnBasedGameFramework", LoadConfig.SourceLevel());

            // Text listener
            string loggerFilePath = Directory.GetCurrentDirectory() + "/log.txt";
            using StreamWriter sw = new StreamWriter(File.Create(loggerFilePath));
            TraceListener textListener = new TextWriterTraceListener(sw);
            theTraceSource.Listeners.Add(textListener);

            // Json listener
            string jsonLoggerFilePath = Directory.GetCurrentDirectory() + "/log.json";
            TraceListener jsonListener = new JsonTraceListener(jsonLoggerFilePath);
            theTraceSource.Listeners.Add(jsonListener);

            return theTraceSource;
        }

        /// <summary>
        /// Logs a message to the Listeners of the TraceSource.
        /// </summary>
        /// <param name="traceEvent">The log level of the incoming message (Informational, Warning, Error, Critical, Verbose)</param>
        /// <param name="message">The message you want to log</param>
        public static void Log(TraceEventType traceEvent, string message)
        {
            if (_tracer == null)
            {
                _tracer = InitialiseTraceListener();
            }
            _tracer.TraceEvent(traceEvent, 0, message);
        }
    }
}
