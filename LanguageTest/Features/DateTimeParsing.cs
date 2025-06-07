using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTest.Features;

public class DateTimeParsing : IFeature
{
    public void Action()
    {
        var culture = new CultureInfo("en-US");
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
        Thread.CurrentThread.CurrentUICulture = culture;

        // country code list https://www.andiamo.co.uk/resources/iso-language-codes/

        // gmt+2 a cel
        // ugy hogy a current culture mind1, de akkor legyen egy gmt+4
        var gmt4 = CultureInfo.CreateSpecificCulture("ar-ae");
        var dt = DateTimeOffset.ParseExact("10/4/22 18:35", "M/d/yy H:m", gmt4, DateTimeStyles.AssumeLocal);

        var dt2 = DateTime.ParseExact("10/4/22 18:35", "M/d/yy H:m", gmt4, DateTimeStyles.AssumeLocal);
        var dt3 = DateTime.Parse("10/4/22 18:35", gmt4);
        var tz = TimeZoneInfo.ConvertTime(dt2, TimeZoneInfo.CreateCustomTimeZone("blabla", TimeSpan.FromHours(4), "disp", "daasd"));

        // convert any time and date to specified timezone with keeping hours intact
        var dt1 = DateTimeOffset.Parse("10/4/22 18:35");
        var tz1 = TimeZoneInfo.ConvertTime(dt1, TimeZoneInfo.FindSystemTimeZoneById("West Asia Standard Time"));
        var a = tz1.ToUniversalTime();
    }
}
