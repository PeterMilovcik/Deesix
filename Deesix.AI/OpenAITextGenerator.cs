using OpenAI;
using OpenAI.Chat;

namespace Deesix.AI;

public class OpenAITextGenerator
{
    private string ApiKey { get; }

    public OpenAITextGenerator(string apiKey)
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

    public async Task<string> GenerateTextAsync(string systemPrompt, string userPrompt)
    {
        var openAIClient = new OpenAIClient(new OpenAIAuthentication(ApiKey));
        var messages = new List<Message>
        {
            new Message(Role.System, systemPrompt),
            new Message(Role.User, userPrompt),
        };
        var chatRequest = new ChatRequest(messages);
        var response = await openAIClient.ChatEndpoint.GetCompletionAsync(chatRequest);
        var result = response.FirstChoice.Message.Content;
        return result;
    }
}
