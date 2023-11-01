using Deesix.AI;

namespace Deesix.Test.AI;

public class OpenAITextGeneratorTests
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
    [Explicit("This test is not meant to be run as part of the build process. It is meant to be run manually to test the OpenAI API.")]
    public async Task GenerateTextAsync()
    {
        string systemPrompt = "You are a RPG game master.";
        string userPrompt = "Generate a name for the world.";
        string text = await new OpenAITextGenerator(ApiKey).GenerateTextAsync(systemPrompt, userPrompt);
        Assert.That(text, Is.Not.Null, "The generated text is null.");
        Assert.That(text, Is.Not.Empty, "The generated text is empty string.");
        Console.WriteLine($"Generated text: {text}");
    }
}
