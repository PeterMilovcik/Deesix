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

            var themes = new List<string>
            {
                "High Fantasy",
                "Medieval",
                "Steampunk",
                "Cyberpunk",
                "Space Opera",
                "Post-Apocalyptic",
                "Urban Fantasy",
                "Western",
                "Desert Kingdoms",
                "Eastern Mythology",
                "Nordic Mythology"
            };
            var themesString = string.Join(", ", themes);

            var systemPrompt = 
                $"You are an AI tasked with creating a unique setting for a role-playing game " + 
                $"based on the following schema: {schemaJson}. " + 
                "The description for world should be max. 300 characters long." +
                $"The theme should be chosen from the following list: {themesString}.";
            var userPrompt = 
                "Generate a world setting in a JSON format conforming to the provided schema.";
            
            var generatedJson = await OpenAITextGenerator.GenerateTextAsync(systemPrompt, userPrompt);
            
            WorldSettings worldSettings = JsonSerializer.Deserialize<WorldSettings>(generatedJson);
            
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
