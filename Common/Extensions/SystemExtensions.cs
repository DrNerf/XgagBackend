using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public static class SystemExtensions
    {
        public static double GetJSTimeStamp(this DateTime dateTime)
        {
            return dateTime.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds;
        }
    }
}
