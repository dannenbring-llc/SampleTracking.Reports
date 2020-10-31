using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public class LoggingHelper
    {
        public static LogEventLevel GetLogLevel(string logEventLevel)
        {
            switch (logEventLevel.ToLower())
            {
                case "error":
                    return LogEventLevel.Error;
                case "information":
                    return LogEventLevel.Information;
                case "debug":
                    return LogEventLevel.Debug;
                default:
                    return LogEventLevel.Error;
            }
        }

    }
}
