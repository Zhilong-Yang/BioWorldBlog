﻿using System;
using System.Collections.Generic;

namespace BioWorld.DateTimeService
{
    public interface IDateTimeService
    {
        DateTime GetNowWithUserTZone();
        DateTime GetDateTimeWithUserTZone(DateTime utcDateTime);
        DateTime GetUtcTimeFromUserTZone(DateTime userDateTime);
        IEnumerable<TimeZoneInfo> GetTimeZones();
        TimeSpan GetTimeSpanByZoneId(string timeZoneId);
    }
}