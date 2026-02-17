

using System;
using AdventureGame.Core.Models;
using AdventureGame.Core.Services;

namespace AdventureGame.Console;

class Program
{
    static void Main(string[] args)
    {
        
            var player = new Player();

            var mazeGenerator = new MazeGeneratorLogics();
            Random random = new Random();
            
            System.Console.WriteLine("Creating maze...");
            var maze = new Maze(random.Next(10, 15), mazeGenerator);
            System.Console.WriteLine("Maze created successfully!");

            var fightLogic = new FightLogic();
            var itemCollecting = new ItemCollecting();
            var weaponSelecting = new WeaponSelectingLogic();
            var playerTileChange = new PlayerTileChangeLogic();
            var potionConsumeLogic = new PotionConsumeLogics();

            System.Console.WriteLine("-----Welcome to the Adventure Game!-----");
            System.Console.WriteLine("--Instructions--\nPlease use WASD keys to move and use 'R' key to consume potions.");
            System.Console.WriteLine("Press any key to start the game...");
            System.Console.ReadKey();

            string actionMessage = "Game started!";

            while (true)
            {
                 // Console.Clear() was clearing the texts but not old the mazes from console i Watched videos about the reason and solutions 
                 // and setting buffer = windows was a recommended solution but didnt work i am  leaving it here as the proof i worked on that.
                System.Console.SetBufferSize(System.Console.WindowWidth, System.Console.WindowHeight);
                for (int i = 0; i < System.Console.WindowHeight; i++)
                            {
                            System.Console.WriteLine(new string(' ', System.Console.WindowWidth - 1));
                        }
                System.Console.Clear();
                MazeRenderingLogic.MazeRender(maze);                
                System.Console.WriteLine("\n-----------------------------");
                System.Console.WriteLine($"HP: {player.Health} | Damage: {player.DamageDealt} | Inventory: {player.Inventory.Count} items");
                System.Console.WriteLine($"Action: {actionMessage}");
                System.Console.WriteLine("-----------------------------");
                System.Console.WriteLine("\nPlease use WASD keys to move and use 'R' key to consume potions.");
                
                char input = System.Console.ReadKey(true).KeyChar;
                
                
                actionMessage = playerTileChange.ChangePlayerTile(
                    maze, input, fightLogic, player, weaponSelecting, itemCollecting, potionConsumeLogic);
                

                if (player.Health <= 0)
                {
                    System.Console.Clear();
                    MazeRenderingLogic.MazeRender(maze);
                    System.Console.WriteLine("\n GAME OVER! You have been defeated!");
                    System.Console.WriteLine("Press any key to exit...");
                    System.Console.ReadKey();
                    break;
                }
                
                if (actionMessage == "Congratulations! You found the exit!")
                {
                    System.Console.Clear();
                    MazeRenderingLogic.MazeRender(maze);
                    System.Console.WriteLine($"\n {actionMessage}");
                    System.Console.WriteLine("Press any key to exit...");
                    System.Console.ReadKey();
                    break;
                }
            }
        
    }
}