using AdventureGame.Core.Models;
using AdventureGame.Core.Interfaces;
using AdventureGame.Core.Enums;

namespace AdventureGame.Core.Services;

public class PlayerTileChangeLogic
{
    
    public string ChangePlayerTile(Maze maze, char keyPressed, FightLogic fightLogic, Player player, WeaponSelectingLogic weaponSelectingLogic, ItemCollecting itemCollecting, PotionConsumeLogics potionConsumeLogics)
    {   
        Direction? direction = null;
        
        keyPressed = char.ToLower(keyPressed);
        
        (int x, int y) previousPosition = maze.PlayerPosition;
      
        // Determine direction based on key pressed
        switch (keyPressed)
        {
            case 'w': direction = Direction.Up; break;
            case 's': direction = Direction.Down; break;
            case 'a': direction = Direction.Left; break;
            case 'd': direction = Direction.Right; break; 
            case 'r': return potionConsumeLogics.UseHealthPotion(player);
            default:
                return "Invalid input, use WASD keys to move.";
        }
        
        // Calculate new position based on direction
        switch (direction)
        {
            case Direction.Up: 
                maze.PlayerPosition = (maze.PlayerPosition.x, maze.PlayerPosition.y - 1);
                break;
            case Direction.Down:
                maze.PlayerPosition = (maze.PlayerPosition.x, maze.PlayerPosition.y + 1);
                break;
            case Direction.Left:
                maze.PlayerPosition = (maze.PlayerPosition.x - 1, maze.PlayerPosition.y);
                break;
            case Direction.Right:
                maze.PlayerPosition = (maze.PlayerPosition.x + 1, maze.PlayerPosition.y);
                break;
            default: return "";
        }

        // Check if new position is valid
        if (maze.TileFeature[maze.PlayerPosition.x, maze.PlayerPosition.y] == TileType.Wall)
        {
            maze.PlayerPosition = previousPosition;
            return "You hit a wall! Try a different direction.";
        }
        else if (maze.TileFeature[maze.PlayerPosition.x, maze.PlayerPosition.y] == TileType.Exit)
        {
            return "Congratulations! You found the exit!";
        }
        else if (maze.TileFeature[maze.PlayerPosition.x, maze.PlayerPosition.y] == TileType.Monster)
        {
            
            Monster newMonster = new Monster();
            string result = fightLogic.FightLoop(player, newMonster); 
            
            if (player.Health > 0)
            {
                maze.TileFeature[maze.PlayerPosition.x, maze.PlayerPosition.y] = TileType.Player;
                maze.TileFeature[previousPosition.x, previousPosition.y] = TileType.Empty;
            }
            else
            {
                
                maze.PlayerPosition = previousPosition;
            }
            return result;
        }
        else if (maze.TileFeature[maze.PlayerPosition.x, maze.PlayerPosition.y] == TileType.Weapon)
        {
            Weapon tempWeapon = new Weapon("Found Weapon", 5); 
            string msg = itemCollecting.CollectItem(player, tempWeapon);
            weaponSelectingLogic.SelectWeapon(player);

            maze.TileFeature[maze.PlayerPosition.x, maze.PlayerPosition.y] = TileType.Player;
            maze.TileFeature[previousPosition.x, previousPosition.y] = TileType.Empty;
            return msg;
        }
        else if (maze.TileFeature[maze.PlayerPosition.x, maze.PlayerPosition.y] == TileType.Potion)
        {
            HealthPotion tempPotion = new HealthPotion("Health Potion", 20);
            string msg = itemCollecting.CollectItem(player, tempPotion);

            maze.TileFeature[maze.PlayerPosition.x, maze.PlayerPosition.y] = TileType.Player;
            maze.TileFeature[previousPosition.x, previousPosition.y] = TileType.Empty;
            return msg;
        }
        
        // Empty tile
        maze.TileFeature[maze.PlayerPosition.x, maze.PlayerPosition.y] = TileType.Player;
        maze.TileFeature[previousPosition.x, previousPosition.y] = TileType.Empty;
        return string.Empty;
    }
}