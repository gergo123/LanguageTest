using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LanguageTest.Features;

public class DateTimeParsing : IFeature
{
    public void Action()
    {
        // country code list https://www.andiamo.co.uk/resources/iso-language-codes/

        var timezone = TimeZoneInfo.FindSystemTimeZoneById("Europe/Budapest");
        var date = DateTime.Parse("10/4/22 18:35");
        var newUtcDateInTimeZone = ConvertToUtcFromTimeZone(date, timezone);
    }

    public DateTime ConvertToUtcFromTimeZone(DateTime date, TimeZoneInfo timeZone)
    {
        return TimeZoneInfo.ConvertTimeToUtc(date,
           date.Kind == DateTimeKind.Local ? TimeZoneInfo.Local :
           date.Kind == DateTimeKind.Utc ? TimeZoneInfo.Utc : timeZone);
    }
}
