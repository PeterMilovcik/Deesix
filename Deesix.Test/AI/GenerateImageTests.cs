using Deesix.AI;

namespace Deesix.Test.AI;

[TestFixture]
public class GenerateImageTests
{
    private string ApiKey = string.Empty;

    [SetUp]
    public void SetUp()
    {
        ApiKey = Environment.GetEnvironmentVariable("OPEN_AI_KEY") ?? string.Empty;
        Assert.That(ApiKey, Is.Not.Empty, "The OPEN_AI_KEY environment variable is not set.");
        Assert.That(ApiKey.StartsWith("sk-"), "The ApiKey does not start with 'sk-'");
    }
    
    [Test]
    public async Task GenerateImageAsync()
    {
        string prompt = "A serene beach with a setting sun";
        string url = await new ImageGenerator(ApiKey!).GenerateTemporalImageUrl(prompt);
        Assert.That(url, Is.Not.Null, "The generated url is null");
        Console.WriteLine($"Generated image url: {url}");
    }
}
