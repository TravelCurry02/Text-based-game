using System;
using System.IO;
using System.Text.Json;

public static class FileManager
{
    public static T ReadFromFile<T>(string filePath)
    {
        try // Added try-catch for error handling
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File not found: {filePath}");
            }

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(json);
        }
        catch (Exception ex) //Handle file or deserialization errors
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
            return default; // Return a default value if deserialization fails
        }
    }

    public static void WriteToFile<T>(string filePath, T data)
    {
        string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }
}