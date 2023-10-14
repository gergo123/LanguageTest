using System.Text.Json;
using System.Text.Json.Serialization;

namespace LanguageTest.Features.c8;

// Positional syntax
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record#positional-syntax-for-property-definition
public record NewsItem(
    string title,
    string description,
    string category,
    double score,
    string guid,
    string author,
    string url,
    DateTime? publishedAt,
    string urlToImage
    // todo "source":{"name":"CNBC"}
    )
{
}

public class RecordsC8 : IFeature
{
    public void Action()
    {
        return;

        List<NewsItem> items = new();
        var txtFiles = Directory.EnumerateFiles(
                "C:\\Users\\csovi\\OneDrive\\Desktop\\ml data",
                "*.*",
                SearchOption.AllDirectories
            );
        foreach (var filePath in txtFiles)
        {
            var content = File.ReadAllLines(filePath);
            var paddedContent = $"[{string.Join(',', content)}]";
            var deserialized = JsonSerializer.Deserialize<NewsItem[]>(paddedContent);
            items.AddRange(deserialized);
        }
    }
}
