using System;
using System.Collections.Generic;

namespace BioWorld.DateTimeResolver
{
    public interface IDateTimeResolver
    {
        DateTime GetNowWithUserTZone();
        DateTime GetDateTimeWithUserTZone(DateTime utcDateTime);
        DateTime GetUtcTimeFromUserTZone(DateTime userDateTime);
        IEnumerable<TimeZoneInfo> GetTimeZones();
        TimeSpan GetTimeSpanByZoneId(string timeZoneId);
    }
}