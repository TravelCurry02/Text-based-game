using System;

class Program
{
    static void Main(string[] args)
    {
        string playerDataPath = "Data/playerData.json";
        string textsPath = "Data/texts.json";
        
        PlayerData player;
        if (System.IO.File.Exists(playerDataPath))
        {
            player = PlayerData.Load(playerDataPath);
            Console.WriteLine($"Welcome back, {player.Name}!");
        }
        else
        {
            Console.Write("Enter your player name: ");
            string playerName = Console.ReadLine();
            player = new PlayerData { Name = playerName };
            player.Save(playerDataPath);
        }
        
        TextManager textManager = new TextManager(textsPath);

        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Explore");
            Console.WriteLine("2. Check Status");
            Console.WriteLine("3. Move");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine(textManager.GetText("explore"));
                    break;
                case "2":
                    Console.WriteLine($"Your health is {player.Health}. Your score is {player.Score}.");
                    break;
                case "3":
                    Console.WriteLine(textManager.GetText("move"));
                    break;
                case "4":
                    Console.WriteLine(textManager.GetText("quit"));
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
            
            player.Save(playerDataPath);
        }
    }
}
