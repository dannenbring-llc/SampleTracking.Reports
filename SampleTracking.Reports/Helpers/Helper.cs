using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Rogison.Web.Helpers
{
    public class Helper
    {
        public const string DATE_FORMAT = "MM/dd/yyyy";
        public const string DATE_TIME24_FORMAT = "MM/dd/yyyy HH:mm";
        public const string DATE_TIME24_FORMAT_SS = "MM/dd/yyyy HH:mm:ss";
        public const string DATE_TIME12_FORMAT = "MM/dd/yyyy hh:mm tt";
        public const string TIME12_FORMAT = "hh:mm tt";
        public const string TIME24_FORMAT = "HH:mm";


        public static DateTime? ConvertToDateTime(string date, string time = "00:00")
        {
            if (string.IsNullOrEmpty(time))
            {
                return null;
            }

            // change time format from HHmm to HH:mm ex: 0530 to 05:30
            if (time.Length == 4 && time.IndexOf(":") == -1)
            {
                time = Helper.ToHHmm(time);
            }

            DateTime dateTime;
            bool valid = DateTime.TryParseExact(date + " " + time, Helper.DATE_TIME24_FORMAT, DateTimeFormatInfo.CurrentInfo, DateTimeStyles.None, out dateTime);
            if (valid)
            {
                return dateTime;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Formats a 4 char string of the form HHmm to HH:mm
        /// </summary>
        public static string ToHHmm(string time)
        {
            if (string.IsNullOrEmpty(time) || time.Length != 4)
            {
                throw new ArgumentException("Parameter 'time' must be a valid time in 24 hour format - HHmm");
            }

            return string.Format("{0}:{1}", time.Substring(0, 2), time.Substring(2));
        }


        /// <summary>
        /// Return true if a string of the form HH:mm is a valid time
        /// </summary>
        public static bool IsTime24(string time)
        {
            char[] splitter = { ':' };
            string[] stime = time.Split(splitter);

            if (stime.Length != 2)
            {
                return false;
            }

            int hour, min;
            try
            {
                hour = Convert.ToInt32(stime[0]);
                min = Convert.ToInt32(stime[1]);
            }
            catch
            {
                return false;
            }

            if ((hour < 0 || hour > 23) || (min < 0 || min > 59))
            {
                return false;
            }

            return true;
        }

        public static bool IsTime12(string time)
        {
            char[] splitter = { ':', ' ' };
            string[] stime = time.Split(splitter);

            if (stime.Length != 3)
            {
                return false;
            }

            int hour, min;
            string ampm;
            try
            {
                hour = Convert.ToInt32(stime[0]);
                min = Convert.ToInt32(stime[1]);
                ampm = stime[2].ToUpper();
            }
            catch
            {
                return false;
            }

            if ((hour < 0 || hour > 12) || (min < 0 || min > 59) || (ampm != "AM" && ampm != "PM"))
            {
                return false;
            }

            return true;
        }


        public static T GetValue<T>(object value)
        {
            Type type = typeof(T);

            if (value == DBNull.Value || value == null || string.IsNullOrEmpty(Convert.ToString(value)))
            {
                return default(T);
            }

            if (IsNullableType(type))
            {
                // GET THE UNDERLYING TYPE
                //type = typeof(T).GetGenericArguments()[0];
                type = Nullable.GetUnderlyingType(typeof(T));
            }

            return (T)Convert.ChangeType(value, type);
        }

        /// <summary>
        /// http://msdn.microsoft.com/en-us/library/ms366789(v=vs.110).aspx
        /// Use the following code to determine whether a Type object represents a Nullable type. 
        /// Remember that this code always returns false if the Type object was returned from a call to GetType.
        /// </summary>
        public static bool IsNullableType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
        }
    }
}
