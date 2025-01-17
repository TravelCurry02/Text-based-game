using System;
using System.IO;
using System.Text.Json;

public static class FileManager
{
    public static T ReadFromFile<T>(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File not found: {filePath}");
        }

        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(json);
    }

    public static void WriteToFile<T>(string filePath, T data)
    {
        string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }
}