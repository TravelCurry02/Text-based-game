using System;
using System.IO;
using System.Text.Json;

public static class FileManager
{
    public static T ReadFromFile<T>(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                return default; // Retorna null se o arquivo não existir
            }

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
            return default;
        }
    }

    public static void WriteToFile<T>(string filePath, T data)
    {
        try
        {
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing file: {ex.Message}");
        }
    }
}