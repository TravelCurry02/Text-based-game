# Text-Based Adventure Game

## Overview
Welcome to **Pathfinder's Quest**, an immersive journey into a world of exploration, adventure, and decision-making! This game is built in C# and leverages object-oriented principles to create a dynamic and engaging experience. Players navigate through various rooms, encounter random events, and manage their health and score as they progress.

---

## Features

- **Player Persistence**: Save and load player data, including name, health, and score, to continue your journey anytime.
- **Dynamic Room Navigation**: Explore interconnected rooms with unique descriptions and random events.
- **Interactive Events**: Encounter scenarios like finding treasures, falling into traps, or regaining health.
- **Customizable Experience**: Easily extend rooms, events, and game logic.
- **File Management**: Read and write data seamlessly using JSON serialization.

---

## File Structure

```
├── Program.cs          // Entry point for the game
├── FileManager.cs      // Handles file read/write operations
├── PlayerData.cs       // Represents player attributes and persistence
├── Rooms.cs            // Defines room properties and navigation logic
├── TextManager.cs      // Manages in-game text strings
├── Data
│   ├── playerData.json // Stores player data (generated during gameplay)
│   ├── texts.json      // Stores in-game texts
```

---

## How to Play

1. **Launch the Game**:
   - On starting, choose between creating a new player or continuing with an existing player.

2. **Game Options**:
   - Explore the world to encounter random events.
   - Check your current health and score.
   - Move between rooms in different directions (north, south, east, west).
   - Quit the game, with progress saved automatically.

3. **Events**:
   - Rooms trigger random events such as:
     - Finding treasure (+10 score)
     - Falling into a trap (-20 health)
     - Resting to regain health (+10 health)

---

## Code Architecture

### **1. Program.cs**

- Acts as the main entry point.
- Handles menu navigation (New Player, Continue, Quit).
- Coordinates the core game loop, including saving and loading player data.

### **2. FileManager.cs**

- Provides generic methods to read and write data using JSON serialization.
- Ensures data persistence for players and game texts.

### **3. PlayerData.cs**

- Represents the player with attributes:
  - Name
  - Health (default: 100)
  - Score (default: 0)
- Includes methods for saving and loading player data.

### **4. Rooms.cs**

- Defines room attributes such as:
  - Description
  - Neighbors (linked rooms)
  - Events (random occurrences in the room)
- Manages room connections and event triggering.

### **5. TextManager.cs**

- Reads predefined in-game text from `texts.json`.
- Provides an interface for retrieving text strings by key.

---

## Data Files

### **playerData.json**

- Stores player information, updated dynamically during gameplay.

```json
{
  "playerName": {
    "Name": "John",
    "Health": 80,
    "Score": 20
  }
}
```

### **texts.json**

- Contains predefined text strings for various game actions.

```json
{
  "explore": "You explore the world...",
  "checkStatus": "Your health is 100. Your score is 0.",
  "move": "You move to another location.",
  "quit": "Goodbye!"
}
```

---

## Installation and Setup

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/TravelCurry02/Text-based-game
   ```

2. **Navigate to the Project Directory**:
   ```bash
   cd text-based-adventure-game
   ```

3. **Build and Run**:
   - Open the project in your preferred C# IDE (e.g., Visual Studio, Rider).
   - Build the solution.
   - Run the program.

---

## Possible Future Enhancements

- Add more room types with unique descriptions and events.
- Implement player inventory and item collection.
- Introduce enemy encounters and combat mechanics.
- Create a visual map for room navigation.

---

## Acknowledgments

Thank you for playing **Pathfinder's Quest**! Feel free to suggest improvements or report issues in the repository.