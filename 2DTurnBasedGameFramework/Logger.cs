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
    /// <summary>
    /// A simple Logger for this framework. Logs any Logger.Log() messages into a Log.txt file and a Log.json file.
    /// </summary>
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
            string loggerFilePath = Directory.GetCurrentDirectory() + "/Log.txt";
            using StreamWriter sw = new StreamWriter(File.Create(loggerFilePath)) {AutoFlush = true};
            TraceListener textListener = new TextWriterTraceListener(sw);
            theTraceSource.Listeners.Add(textListener);
            // BUG: Make textListener work... ? It generates the file, but not sure if it writes to it.

            // Json listener
            string jsonLoggerFilePath = Directory.GetCurrentDirectory() + "/Log.json";
            TraceListener jsonListener = new JsonTraceListener(jsonLoggerFilePath);
            theTraceSource.Listeners.Add(jsonListener);

            return theTraceSource;
        }

        /// <summary>
        /// Logs a message to the Listeners of the TraceSource.
        /// </summary>
        /// <param name="traceType">The log level of the incoming message (Informational, Warning, Error, Critical, Verbose)</param>
        /// <param name="message">The message you want to log</param>
        public static void Log(TraceEventType traceType, string message)
        {
            try
            {
                if (_tracer == null)
                {
                    _tracer = InitialiseTraceListener();
                }
                _tracer.TraceEvent(traceType, 0, $"{DateTime.Now.TimeOfDay:g}: {message}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }
    }
}
