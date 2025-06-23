using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTest.Extensions;

public static class DateTimeExtensions
{
    public static DateTime ConvertToUtcFromTimeZone(this DateTime date, TimeZoneInfo timeZone)
    {
        return TimeZoneInfo.ConvertTimeToUtc(date,
           date.Kind == DateTimeKind.Local ? TimeZoneInfo.Local :
           date.Kind == DateTimeKind.Utc ? TimeZoneInfo.Utc : timeZone);
    }
}
