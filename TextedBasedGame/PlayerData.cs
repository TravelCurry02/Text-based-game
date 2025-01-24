using System;
public class PlayerData
{
    public string Name { get; set; }
    public int Health { get; set; } = 100;
    public int Score { get; set; } = 0;
    public string LastCheckpoint { get; set; }

    public void Save(string filePath)
    {
        FileManager.WriteToFile(filePath, this);
    }

    public static PlayerData Load(string filePath)
    {
        return FileManager.ReadFromFile<PlayerData>(filePath);
    }
}