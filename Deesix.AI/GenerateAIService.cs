using System.Text.Json;
using Deesix.Domain.Interfaces;
using Deesix.Domain.Entities;

namespace Deesix.AI;

public class GenerativeAIService : IGenerativeAIService
{    
    private OpenAIImageGenerator OpenAIImageGenerator { get; }
    private OpenAITextGenerator OpenAITextGenerator { get; }

    public GenerativeAIService(string apiKey)
    {
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new ArgumentException($"'{nameof(apiKey)}' cannot be null or whitespace.", nameof(apiKey));
        }
        if (!apiKey.StartsWith("sk-"))
        {
            throw new ArgumentException($"'{nameof(apiKey)}' must start with 'sk-'", nameof(apiKey));
        }

        OpenAIImageGenerator = new OpenAIImageGenerator(apiKey);
        OpenAITextGenerator = new OpenAITextGenerator(apiKey);
    }

    public async Task<WorldSettings> GenerateWorldSettingsAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            string schemaJson = SchemaGenerator.GenerateSchema<WorldSettings>();

            var systemPrompt = 
                $"You are an AI tasked with creating a unique setting for a role-playing game " + 
                $"based on the following JSON: {schemaJson}. " +
                "Description should be max. 300 characters long. " +
                "Theme should be one of the following: High Fantasy, Medieval, Steampunk, Cyberpunk, Space Opera, Post-Apocalyptic, Urban Fantasy, Western, Desert Kingdoms, Eastern Mythology, Nordic Mythology. ";

            var userPrompt = 
                "Generate a world setting in a JSON format conforming to the provided schema. Be creative!";
            
            var generatedJson = await OpenAITextGenerator.GenerateTextAsync(systemPrompt, userPrompt);

            Console.WriteLine($"Generated json: {generatedJson}");
            
            var worldSettings = JsonSerializer.Deserialize<WorldSettings>(generatedJson);
            
            if (worldSettings == null)
            {
                throw new InvalidOperationException("Deserialization to WorldSettings object failed, resulting in a null instance.");
            }

            var imagePrompt = $"Create image that represents the RPG game world " + 
                $"called \"{worldSettings.Name}\" " + 
                $"described as \"{worldSettings.Description}\" "+
                $"with theme: \"{worldSettings.Theme}\".";
            var imageUrl = await OpenAIImageGenerator.GenerateTemporalImageUrlAsync(imagePrompt);
            
            worldSettings.ImageUrl = imageUrl;

            Console.WriteLine($"Generated world settings: {worldSettings}");

            return worldSettings;
        }
        catch (JsonException jsonEx)
        {
            // Handle JSON deserialization exception
            Console.WriteLine($"JSON Deserialization Error: {jsonEx.Message}");
            throw;
        }
        catch (Exception ex)
        {
            // Handle other types of exceptions
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }
}