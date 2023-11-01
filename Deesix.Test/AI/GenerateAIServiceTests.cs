using Deesix.AI;

namespace Deesix.Test.AI;

[TestFixture]
public class GenerateAIServiceTests
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
    [Explicit("This test is not meant to be run as part of the build process. It is meant to be run manually.")]
    public async Task GenerateWorldSettings()
    {
        var service = new GenerativeAIService(ApiKey);
        var result = await service.GenerateWorldSettingsAsync();
        Assert.That(result, Is.Not.Null, "The generated world settings are null.");
        Assert.That(result.Name, Is.Not.Null, "The generated world settings name is null.");
        Assert.That(result.Description, Is.Not.Null, "The generated world settings description is null.");
        Assert.That(result.Theme, Is.Not.Null, "The generated world settings theme is null.");
        Console.WriteLine(result.ToString());
    }
}
