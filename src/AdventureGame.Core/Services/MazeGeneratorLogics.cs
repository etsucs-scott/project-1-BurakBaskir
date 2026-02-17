using AdventureGame.Core.Models;
using AdventureGame.Core.Interfaces;
using AdventureGame.Core.Enums;

namespace AdventureGame.Core.Services;

public class MazeGeneratorLogics
{
    private Random random = new Random();

    public void GenerateFinalMaze(Maze maze)
    {
        GenerateInitialMazeState(maze);
        GenerateMazeBorders(maze);
        PlacePlayerInMaze(maze);
        PlaceExitInMaze(maze);
        PlaceMonstersInMaze(maze);
        PlaceWeaponsInMaze(maze);
        PlacePotionsInMaze(maze); 
    }

    public void GenerateInitialMazeState(Maze maze) // at first state all tiles are being created empty
    {
        for (int x = 0; x < maze.Width; x++)   
        {
            for (int y = 0; y < maze.Height; y++)
            {
                maze.TileFeature[x, y] = TileType.Empty;
            }
        }
    }

    public void GenerateMazeBorders(Maze maze)
    {
        for (int x = 0; x < maze.Width; x++)
        {
            maze.TileFeature[x, 0] = TileType.Wall;    // creates the walls at row above
            maze.TileFeature[x, maze.Height - 1] = TileType.Wall;  // creates the walls at row below 
        }
        for (int y = 0; y < maze.Height; y++)
        {
            maze.TileFeature[0, y] = TileType.Wall;    // creates the walls at the left  columb 
            maze.TileFeature[maze.Width - 1, y] = TileType.Wall;  // creates the walls at the left columb
        }
    }

    public void PlacePlayerInMaze(Maze maze)
    {
        maze.PositionInit = (random.Next(1, maze.Width - 1), 1);   // places player somewhere available  in second row (first row is made of walls)
        maze.PlayerPosition = maze.PositionInit;
        
        maze.TileFeature[maze.PositionInit.x, maze.PositionInit.y] = TileType.Player;
    }

    public void PlaceExitInMaze(Maze maze)
    {
        
        maze.PositionInit = (random.Next(1, maze.Width - 1), maze.Height - 2);   // place exit somewhere in the columb right before last columb (last row consist of walls as well)
        maze.TileFeature[maze.PositionInit.x, maze.PositionInit.y] = TileType.Exit;
    }

    public void PlaceMonstersInMaze(Maze maze)
    {
        int monsterCount = maze.Width / 2;
        for (int i = 0; i < monsterCount; i++)
        {
            
            maze.PositionInit = (random.Next(1, maze.Width - 1), random.Next(1, maze.Height - 1)); // random monster placement 
            
            if (maze.TileFeature[maze.PositionInit.x, maze.PositionInit.y] == TileType.Empty) // createes monssters if the tile is empty
            {
                maze.TileFeature[maze.PositionInit.x, maze.PositionInit.y] = TileType.Monster;
            }
            else
            {
                i--; // if tile is not available runs again without passing the new one
            }
        }
    }

    public void PlaceWeaponsInMaze(Maze maze)
    {
        int weaponCount = maze.Width / 3;
        for (int i = 0; i < weaponCount; i++)
        {
            
            maze.PositionInit = (random.Next(1, maze.Width - 1), random.Next(1, maze.Height - 1));

            
            if (maze.TileFeature[maze.PositionInit.x, maze.PositionInit.y] == TileType.Empty)
            {
                maze.TileFeature[maze.PositionInit.x, maze.PositionInit.y] = TileType.Weapon;
            }
            else
            {
                i--; 
            }
        }
    }

    public void PlacePotionsInMaze(Maze maze)
    {
        int potionCount = maze.Width / 4;
        for (int i = 0; i < potionCount; i++)
        {
            
            maze.PositionInit = (random.Next(1, maze.Width - 1), random.Next(1, maze.Height - 1));

            
            if (maze.TileFeature[maze.PositionInit.x, maze.PositionInit.y] == TileType.Empty)
            {
                maze.TileFeature[maze.PositionInit.x, maze.PositionInit.y] = TileType.Potion;
            }
            else
            {
                i--; 
            }
        }
    }
}