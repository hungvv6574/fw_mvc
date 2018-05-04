using System;
using System.Diagnostics;
using System.Web.Script.Serialization;

namespace CMSSolutions.Websites.Extensions
{
    public class Utilities
    {
        public static T ConvertJsonToObject<T>(string input)
        {
            var json = new JavaScriptSerializer();
            return json.Deserialize<T>(input.Trim());
        }

        public static string ConvertObjectToJson<T>(T input)
        {
            var json = new JavaScriptSerializer();
            return json.Serialize(input);
        }

        public static void WriteEventLog(string messages)
        {
            try
            {
                var eventLogName = "ApplicationErrors";
                if (!EventLog.SourceExists(eventLogName))
                {
                    EventLog.CreateEventSource(eventLogName, "Application Errors");
                }

                var log = new EventLog { Source = eventLogName };
                log.WriteEntry(messages, EventLogEntryType.Error);
            }
            catch (Exception)
            {

            }
        }
    }
}