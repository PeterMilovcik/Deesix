﻿using System.Text.Json;
using Deesix.Domain;
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

            string systemPrompt = 
                $"You are an AI tasked with creating a unique setting for a role-playing game " + 
                $"based on the following schema: {schemaJson}. " + 
                $"The theme should be chosen from the following list: {themesString}.";
            string userPrompt = 
                "Generate a world setting in a JSON format conforming to the provided schema.";
            
            string generatedJson = await OpenAITextGenerator.GenerateTextAsync(systemPrompt, userPrompt);
            
            WorldSettings worldSettings = JsonSerializer.Deserialize<WorldSettings>(generatedJson);
            
            if (worldSettings == null)
            {
                throw new InvalidOperationException("Deserialization to WorldSettings object failed, resulting in a null instance.");
            }
            
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