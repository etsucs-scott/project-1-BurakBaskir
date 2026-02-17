using AdventureGame.Core.Models;
using AdventureGame.Core.Interfaces;
using AdventureGame.Core.Enums;
using System;

namespace AdventureGame.Core.Services;

public class MazeRenderingLogic
{

public static void MazeRender(Maze maze)  // method to display maze in console
{
    for (int y = 0; y < maze.Height; y++)
    {
        for (int x = 0; x < maze.Width; x++)
        {
            char symbol;

            switch (maze.TileFeature[x, y])
            {
                case TileType.Empty:
                    symbol = '.';
                    break;
                case TileType.Wall:
                    symbol = '#';
                    break;
                case TileType.Player:
                    symbol = '@';
                    break;
                case TileType.Monster:
                    symbol = 'M';
                    break;
                case TileType.Weapon:
                    symbol = 'W';
                    break;
                case TileType.Potion:
                    symbol = 'P';
                    break;
                case TileType.Exit:
                    symbol = 'E';
                    break;
                default:
                    symbol = '?';
                    break;
            }

            Console.Write(symbol + " ");
        }
        Console.WriteLine();   // new line after each row
    }
}
}