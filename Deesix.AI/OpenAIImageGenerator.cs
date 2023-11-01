using OpenAI;

namespace Deesix.AI;

public class OpenAIImageGenerator
{
    private string ApiKey { get; }

    public OpenAIImageGenerator(string apiKey)
    {
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new ArgumentException($"'{nameof(apiKey)}' cannot be null or whitespace.", nameof(apiKey));
        }
        if (!apiKey.StartsWith("sk-"))
        {
            throw new ArgumentException($"'{nameof(apiKey)}' must start with 'sk-'", nameof(apiKey));
        }

        ApiKey = apiKey;
    }

    public async Task<string> GenerateTemporalImageUrl(string prompt)
    {
        var openAIClient = new OpenAIClient(new OpenAIAuthentication(ApiKey));
        var imageResult = await openAIClient.ImagesEndPoint.GenerateImageAsync(prompt, 1, OpenAI.Images.ImageSize.Small);        
        return imageResult.First();
    }
}
