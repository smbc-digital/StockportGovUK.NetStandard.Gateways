using System;

namespace StockportGovUK.NetStandard.Gateways.Extensions;

public static class DaylightSavingsExtension
{
    public static DateTime AdjustDateTimeForDaylightSavings(DateTime dateTime)
    {
        TimeZoneInfo ukTimezone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
        bool isCurrentlyBritishSummerTime = ukTimezone.IsDaylightSavingTime(DateTime.UtcNow);
        return isCurrentlyBritishSummerTime ? dateTime.AddHours(1) : dateTime;
    }
}
