using System;
using System.IO;
using RoomMaking;

class Program{
    static void Main(string[] args){
        // The mail loop flag
        bool isRunning = true;

        // The welcome message and game options 
        Console.WriteLine("Welcome to Pathfinder's Quest! Using C#");
        Console.WriteLine("1. I'm a new player");
        Console.WriteLine("2. I want to continue my game");
        Console.WriteLine("3. Quit");
        Console.Write("Choose an option: ");
        string input = Console.ReadLine()!;

        // The path to save or load player data and load existing player data or initialize a new dictionary
        string playerDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Data", "playerData.json");
        var playersData = FileManager.ReadFromFile<Dictionary<string, PlayerData>>(playerDataPath) ?? new Dictionary<string, PlayerData>();

        PlayerData player = null;

        // This handles user input for the menu options 
        if (input == "1"){
            Console.WriteLine();
            Console.WriteLine("What's your name?");
            string playerName = Console.ReadLine()!;

            // This checks if the player already exists then move forward 
            if (playersData.ContainsKey(playerName)){
                Console.WriteLine("Player already exists. Overwriting data...");
            }
            else{
                Console.WriteLine();
                Console.WriteLine($"Welcome, {playerName}! Starting a new game.");
                Console.WriteLine();
            }
            
            // This creates a new player and their save data 
            player = new PlayerData { Name = playerName };
            playersData[playerName] = player;

            SavePlayerData(playerDataPath, playersData);
            Progress(isRunning, player, playersData, playerDataPath);
        }
        else if (input == "2"){

            // This loads an existing player's data 
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
            // Exit the game 
            Console.WriteLine("Goodbye!");
        }
        else{
            // This handles any invalid inputs from the user 
            Console.WriteLine("Invalid option. Exiting...");
        }
    }

    // This handles the main gameplay loop 
    public static void Progress(bool isRunning, PlayerData player, Dictionary<string, PlayerData> playersData, string playerDataPath){
        
        // Loads game text and all the room information
        string textsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Data", "texts.json");
        RoomCreation roomCreation = new RoomCreation();
        Room currentRoom = roomCreation.Rooms["forest"];
        TextManager textManager = new TextManager(textsPath);

        while (isRunning){

            // The mail list of options for a player to choose from
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
                    // Explores the room the player is in currnetly 
                    Console.WriteLine(textManager.GetText("explore"));
                    currentRoom.TriggerEvent(player);
                    break;
                case "2":
                    // Displays the player's status 
                    Console.WriteLine($"Your health is {player.Health}. Your score is {player.Score}.");
                    break;
                case "3":
                    // Move to another room that is neighboring the current room
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
                    // Exits the game 
                    Console.WriteLine(textManager.GetText("quit"));
                    isRunning = false;
                    break;
                default:
                    // Handles any invalid inputs 
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
            // Saves the players progress 
            playersData[player.Name] = player;
            SavePlayerData(playerDataPath, playersData);
        }
    }

    // Saves the player data to a file 
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
