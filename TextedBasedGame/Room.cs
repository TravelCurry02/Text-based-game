using System;
using System.Collections.Generic;
using System.Net.WebSockets;

namespace RoomMaking
{
    public class Room
    {
        // Property for the room's description
        public string Description { get; set; }
        // Dictionary to store neighboring rooms
        public Dictionary<string, Room> Neighbors { get; set; }
        // List to store possible events in the room
        public List<string> Events { get; set; }

        // Constructor to initialize the room
        public Room(string description)
        {
            Description = description;
            Neighbors = new Dictionary<string, Room>();
            Events = new List<string>();
        }

        // Method to trigger events that affect the player
        public void TriggerEvent(PlayerData player)
        {
            if (Events.Count > 0)
            {
                Random rand = new Random();
                int eventIndex = rand.Next(Events.Count);
                string eventOccurred = Events[eventIndex];

                Console.WriteLine($"Event: {eventOccurred}");

                if (eventOccurred == "Found treasure")
                {
                    player.Score += 10; // Increase score
                }
                else if (eventOccurred == "Fell into a trap")
                {
                    player.Health -= 20; // Decrease health
                }
                else if (eventOccurred == "Rested and regained health")
                {
                    player.Health += 10; // Regain health
                }
            }
        }
    }

    public class RoomCreation
    {
        public Dictionary<string, Room> Rooms { get; private set; }

        public RoomCreation()
        {
            Rooms = new Dictionary<string, Room>();
            CreateRooms();
        }

        // Create rooms and assign events to them
        private void CreateRooms()
        {
            Room forest = new Room("You are in a dense forest.");
            forest.Events.Add("Found treasure");
            forest.Events.Add("Fell into a trap");

            Room mountain = new Room("You are on a rocky mountain.");
            mountain.Events.Add("Found treasure");
            mountain.Events.Add("Fell into a trap");

            Room lake = new Room("You are beside a serene lake.");
            lake.Events.Add("Rested and regained health");

            Room mine = new Room("You are within a deep mine. You could find some gems here.");
            mine.Events.Add("Found treasure");

            Room temple = new Room("You are at an abandoned temple.");
            temple.Events.Add("Found treasure");
            temple.Events.Add("Fell into a trap");
            temple.Events.Add("Rested and Regain Health");

            Room marsh = new Room("You are in a disgusting marsh.");
            marsh.Events.Add("Found treasaure");
            marsh.Events.Add("Fell into a trap");

            Room plains = new Room("You are on some grassy plains.");
            plains.Events.Add("Found treasure");
            plains.Events.Add("Fell into a trap");
            plains.Events.Add("Rested and Regain Health");

            Room volcano = new Room("You are near a blistering volcano. Thankfully its not erupting.");
            volcano.Events.Add("Found treasure");
            volcano.Events.Add("Fell into a trap");
        
            Room tundra = new Room("You are in a freezing tundra.");
            tundra.Events.Add("Found treasure");
            tundra.Events.Add("Fell into a trap");
        

            forest.Neighbors["north"] = mountain;
            forest.Neighbors["south"] = lake;
            forest.Neighbors["east"] = temple;
            forest.Neighbors["west"] = volcano;
            mountain.Neighbors["south"] = forest;
            mountain.Neighbors["north"] = lake;
            mountain.Neighbors["east"] = plains;
            mountain.Neighbors["west"] = marsh;
            lake.Neighbors["south"] = mountain;
            lake.Neighbors["north"] = forest;
            lake.Neighbors["east"] = mine;
            lake.Neighbors["west"] = tundra;
            mine.Neighbors["south"] = plains;
            mine.Neighbors["north"] = temple;
            mine.Neighbors["east"] = tundra;
            mine.Neighbors["west"] = lake;
            temple.Neighbors["south"] = mine;
            temple.Neighbors["north"] = plains;
            temple.Neighbors["east"] = volcano;
            temple.Neighbors["west"] = forest;
            plains.Neighbors["south"] = temple;
            plains.Neighbors["north"] = mine;
            plains.Neighbors["east"] = marsh;
            plains.Neighbors["west"] = mountain;
            marsh.Neighbors["south"] = volcano;
            marsh.Neighbors["north"] = tundra;
            marsh.Neighbors["east"] = mountain;
            marsh.Neighbors["west"] = plains;
            volcano.Neighbors["south"] = tundra;
            volcano.Neighbors["north"] = marsh;
            volcano.Neighbors["east"] = forest;
            volcano.Neighbors["west"] = temple;
            tundra.Neighbors["south"] = marsh;
            tundra.Neighbors["north"] = volcano;
            tundra.Neighbors["east"] = lake;
            tundra.Neighbors["west"] = mine;

            Rooms["forest"] = forest;
            Rooms["mountain"] = mountain;
            Rooms["lake"] = lake;
            Rooms["mine"] = mine;
            Rooms["temple"] = temple;
            Rooms["marsh"] = marsh;
            Rooms["plains"] = plains;
            Rooms["volcano"] = volcano;
            Rooms["tundra"] = tundra;
        }
    }
}