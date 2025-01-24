using System;
public class PlayerData
{
    // Player's name
    public string Name { get; set; }

    //Player's health, the default value is 100
    public int Health { get; set; } = 100;

    // Player's score, default value is 0
    public int Score { get; set; } = 0;

    // The last checkpoint the player reached 
    public string LastCheckpoint { get; set; }

    // Save player data to a specified file
    public void Save(string filePath)
    {
        FileManager.WriteToFile(filePath, this);
    }

    // Load a player's data from a specified file
    public static PlayerData Load(string filePath)
    {
        return FileManager.ReadFromFile<PlayerData>(filePath);
    }
}