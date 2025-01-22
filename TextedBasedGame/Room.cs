using System;
using System.Collections.Generic;

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
            Room forest = new Room("You are in a dense forest. Paths lead north and south.");
            forest.Events.Add("Found treasure");
            forest.Events.Add("Fell into a trap");

            Room mountain = new Room("You are on a rocky mountain. Paths lead east and west.");
            mountain.Events.Add("Found treasure");
            mountain.Events.Add("Fell into a trap");

            Room lake = new Room("You are beside a serene lake. Paths lead south and west.");
            lake.Events.Add("Rested and regained health");

            forest.Neighbors["north"] = mountain;
            forest.Neighbors["south"] = lake;
            mountain.Neighbors["south"] = forest;
            mountain.Neighbors["east"] = lake;
            lake.Neighbors["west"] = mountain;
            lake.Neighbors["north"] = forest;

            Rooms["forest"] = forest;
            Rooms["mountain"] = mountain;
            Rooms["lake"] = lake;
        }
    }
}