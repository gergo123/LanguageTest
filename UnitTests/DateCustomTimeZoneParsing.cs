using FluentAssertions;
using LanguageTest.Extensions;

namespace UnitTests;

[TestClass]
public sealed class DateCustomTimeZoneParsing
{
    [TestMethod]
    public void ParseIntoSpecifiedTimeZone()
    {
        // country code list https://www.andiamo.co.uk/resources/iso-language-codes/

        var timezone = TimeZoneInfo.FindSystemTimeZoneById("Europe/Budapest");
        var date = DateTime.Parse("10/4/22 18:35");
        var newUtcDateInTimeZone = date.ConvertToUtcFromTimeZone(timezone);
        newUtcDateInTimeZone.Should()
            .Be(new DateTime(2022, 10, 4, 16, 35, 0, DateTimeKind.Utc));
    }
}
