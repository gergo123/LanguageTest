namespace LanguageTest.Features;

// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum#enumeration-types-as-bit-flags
enum BinaryEnum
{
    none = 0b_0000,

    saturday = 0b_0001,
    sunday = 0b_0010,

    weekend = saturday | sunday,
}
