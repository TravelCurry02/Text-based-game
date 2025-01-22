using System;
using RoomMaking;

class Program
{
    static void Main(string[] args)
    {
        bool isRunning = false;
        
        Console.WriteLine("Welcome in Texted Based Game! Using C#");
        Console.WriteLine("1. I'm a new player");
        Console.WriteLine("2. I want continue my game");
        Console.WriteLine("3. Quit");
        Console.Write("Choose an option: ");
        string input = Console.ReadLine()!;
        if (input.ToLower() == "1")
        {
            Console.WriteLine("Whats your name?");
            string playerName = Console.ReadLine()!;
        }
        if (input.ToLower() == "2")
        {
            isRunning = true;
            Progress(isRunning);
        }
    }

    public static void Progress(bool isRunning)
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

        // Room creation and navigation
        RoomCreation roomCreation = new RoomCreation();
        Room currentRoom = roomCreation.Rooms["forest"]; // Starting room

        TextManager textManager = new TextManager(textsPath);
        
        while (isRunning)
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("");
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
                    currentRoom.TriggerEvent(player); // Trigger event when exploring
                    break;
                case "2":
                    Console.WriteLine($"Your health is {player.Health}. Your score is {player.Score}.");
                    break;
                case "3":
                    Console.Write("Which direction would you like to move? (north, south, east, west): ");
                    string direction = Console.ReadLine()?.ToLower(); 

                    if (currentRoom.Neighbors.ContainsKey(direction))
                    {
                        currentRoom = currentRoom.Neighbors[direction];
                        Console.WriteLine($"You move {direction}. {currentRoom.Description}");
                        currentRoom.TriggerEvent(player); // Trigger event when moving
                    }
                    else
                    {
                        Console.WriteLine("Invalid direction. Try again.");
                    }
                    break;
                case "4":
                    Console.WriteLine(textManager.GetText("quit"));
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }

            // Save player data after each action
            player.Save(playerDataPath);
        } 
    }
}

