﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgometerLibrary
{
    public class Helper
    {
        public static double Now { get { return (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds; } }
        
        public static string MillisecondsToTime(double millis)
        {
            DateTime time = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            string timestr = time.AddMilliseconds(millis) + "";
            return timestr;
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string SecondsToTime(int input)
        {
            int hours = input / 3600;
            input %= 3600;

            int minutes = input / 60;
            input %= 60;

            int seconds = input;

            string rtnstr = "";

            if (hours != 0)
            {
                rtnstr += hours.ToString("D2") + ":";
            }

            rtnstr += minutes.ToString("D2") + ":";
            rtnstr += seconds.ToString("D2");

            return rtnstr;
        }
    }
}
