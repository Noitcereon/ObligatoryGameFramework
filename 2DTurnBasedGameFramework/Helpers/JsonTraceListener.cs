using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _2DTurnBasedGameFramework.Helpers
{
    /// <summary>
    /// Logs TraceEventData to a json file.
    /// </summary>
    public class JsonTraceListener : TraceListener
    {
        private readonly string _filePath = Directory.GetCurrentDirectory() + "/Log.json";
        private readonly object _lock = new object();
        private readonly StreamWriter _sw;

        public JsonTraceListener()
        {
            _sw = new StreamWriter(File.Create(_filePath)) {AutoFlush = true};
        }

        /// <param name="filePath">The location of the log file</param>
        public JsonTraceListener(string filePath)
        {
            _filePath = filePath;
            _sw = new StreamWriter(File.Create(_filePath)) {AutoFlush = true};
        }

        /// <inheritdoc />
        public override void Write(string message)
        {
            if (message == null) return;

            string json = JsonSerializer.Serialize(message);
            lock (_lock)
            {
                _sw.Write(json);
            }
        }

        /// <inheritdoc />
        public override void WriteLine(string message)
        {
            if (message == null) return;

            string json = JsonSerializer.Serialize(message);
            lock (_lock)
            {
                _sw.WriteLine(json);
            }
        }
    }
}
