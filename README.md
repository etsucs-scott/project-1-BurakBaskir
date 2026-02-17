# Project 1: Text-Based Adventure Game

a adventure game built in C#. The project consist of 2 main part the game domain logic (Core library) from the user interface (Console application). 

## Git Usage & Setup

To get a local copy up and running, follow these steps:

**1. Clone the repository:**

git clone git@github.com:etsucs-scott/project-1-BurakBaskir.git
cd project-1-BurakBaskir
2. Build the solution:   


dotnet build
3. Run the game: 

dotnet run --project src/AdventureGame.Console


**Controls & Display**
The game is played entirely via the keyboard. The console clears and redraws the map after every valid action.

Movement & Actions:

W  - Move Up

S  - Move Down

A  - Move Left

D  - Move Right

R  - Consume a Health Potion from inventory

**Win/Lose Conditions & Battle Mechanics**

Win Condition: Successfully navigate the maze and step on the tile "E".
Lose Condition: Your HP drop to 0 during a monster encounter.

How Battles Work:

1. Stepping onto a Monster (M) tile initiates combat.

2. The player always attacks first. If the monster survives the hit, it attacks.

3. Player damage is calculated dynamically (Base Damage [10] + Highest Weapon Modifier in inventory). Monster damage is always Base Damage.

4. Once a battle starts, it continues automatically in a loop until either the player or the monster reaches 0 HP.

5. Aftermath: If you win, the monster tile becomes an player tile and you occupy that tile.