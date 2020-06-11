using System;
using System.Collections.Generic;
using System.Text;

namespace BioWorld.Application.Common.Interface
{
    public interface IDateTime
    {
        DateTime GetNowWithUserTZone();
        DateTime GetDateTimeWithUserTZone(DateTime utcDateTime);
        DateTime GetUtcTimeFromUserTZone(DateTime userDateTime);
        IEnumerable<TimeZoneInfo> GetTimeZones();
        TimeSpan GetTimeSpanByZoneId(string timeZoneId);
    }
}
