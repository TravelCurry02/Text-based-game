using System;
using System.IO;
using RoomMaking;
// Program.cs was worked on by Isaac Selph
class Program{
    static void Main(string[] args){
        bool isRunning = true;

        Console.WriteLine("Welcome to Pathfinder's Quest! Using C#");
        Console.WriteLine("1. I'm a new player");
        Console.WriteLine("2. I want to continue my game");
        Console.WriteLine("3. Quit");
        Console.Write("Choose an option: ");
        string input = Console.ReadLine()!;
        
        string playerDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Data", "playerData.json");
        var playersData = FileManager.ReadFromFile<Dictionary<string, PlayerData>>(playerDataPath) ?? new Dictionary<string, PlayerData>();

        PlayerData player = null;

        if (input == "1"){
            Console.WriteLine();
            Console.WriteLine("What's your name?");
            string playerName = Console.ReadLine()!;

            if (playersData.ContainsKey(playerName)){
                Console.WriteLine("Player already exists. Overwriting data...");
            }
            else{
                Console.WriteLine();
                Console.WriteLine($"Welcome, {playerName}! Starting a new game.");
                Console.WriteLine();
            }
            
            player = new PlayerData { Name = playerName };
            playersData[playerName] = player;

            SavePlayerData(playerDataPath, playersData);
            Progress(isRunning, player, playersData, playerDataPath);
        }
        else if (input == "2"){
            Console.Write("Enter your player name: ");
            string playerName = Console.ReadLine()!;

            if (playersData.ContainsKey(playerName)){
                player = playersData[playerName];
                Console.WriteLine($"Welcome back, {playerName}! Your current health is {player.Health} and score is {player.Score}.");
                Console.WriteLine();
                
                Progress(isRunning, player, playersData, playerDataPath);
            }
            else{
                Console.WriteLine("Player not found. Please start a new game.");
            }
        }
        else if (input == "3"){
            Console.WriteLine("Goodbye!");
        }
        else{
            Console.WriteLine("Invalid option. Exiting...");
        }
    }

    public static void Progress(bool isRunning, PlayerData player, Dictionary<string, PlayerData> playersData, string playerDataPath){
        string textsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Data", "texts.json");
        RoomCreation roomCreation = new RoomCreation();
        Room currentRoom = roomCreation.Rooms["forest"];
        TextManager textManager = new TextManager(textsPath);

        while (isRunning){
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("");
            Console.WriteLine("1. Explore");
            Console.WriteLine("2. Check Status");
            Console.WriteLine("3. Move");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an option: ");
            string input = Console.ReadLine()!;

            switch (input){
                case "1":
                    Console.WriteLine(textManager.GetText("explore"));
                    currentRoom.TriggerEvent(player);
                    break;
                case "2":
                    Console.WriteLine($"Your health is {player.Health}. Your score is {player.Score}.");
                    break;
                case "3":
                    Console.Write("Which direction would you like to move? (north, south, east, west): ");
                    string direction = Console.ReadLine()?.ToLower()!;

                    if (currentRoom.Neighbors.ContainsKey(direction)){
                        currentRoom = currentRoom.Neighbors[direction];
                        Console.WriteLine($"You move {direction}. {currentRoom.Description}");
                        currentRoom.TriggerEvent(player);
                    }
                    else{
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
            
            playersData[player.Name] = player;
            SavePlayerData(playerDataPath, playersData);
        }
    }

    private static void SavePlayerData(string playerDataPath, Dictionary<string, PlayerData> playersData){
        try{
            string directory = Path.GetDirectoryName(playerDataPath)!;
            if (!Directory.Exists(directory)){
                Directory.CreateDirectory(directory);
            }

            FileManager.WriteToFile(playerDataPath, playersData);
            Console.WriteLine("Player data successfully saved.");
        }
        catch (Exception ex){
            Console.WriteLine($"Error saving player data: {ex.Message}");
        }
    }
}
