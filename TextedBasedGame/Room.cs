
using System; 
using System.Collections.Generic; 
namespace RoomMaking { 
    class Room { 
    // Property for the room's description 
    public string Description { get; set; } 
    // Dictionary to store neighboring rooms 
    public Dictionary<string, Room> Neighbors { get; set; } 
    // Constructor to initialize the room 
    public Room(string description) { Description = description; Neighbors = new Dictionary<string, Room>(); } }



class RoomCreation{
    private Dictionary<string, Room> rooms;
public RoomCreation(){
    rooms = new Dictionary<string,Room>();
CreateRooms();}


private void CreateRooms() { 
    // Create rooms    
    Room forest = new Room("You are in a dense forest. Paths lead north and south."); 
    Room mountain = new Room("You are on a rocky mountain. Paths lead east and west."); 
    Room lake = new Room("You are beside a serene lake. Paths lead south and west."); 
    // Set neighbors for each room 
    forest.Neighbors["north"] = mountain; 
    forest.Neighbors["south"] = lake; 
    mountain.Neighbors["south"] = forest; 
    mountain.Neighbors["east"] = lake; 
    lake.Neighbors["west"] = mountain; 
    lake.Neighbors["north"] = forest; 
    // Add rooms to the dictionary 
    rooms["forest"] = forest;
     rooms["mountain"] = mountain;
      rooms["lake"] = lake;
}
}
}