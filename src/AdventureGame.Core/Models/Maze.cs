using AdventureGame.Core.Interfaces;
using AdventureGame.Core.Enums;
using AdventureGame.Core.Services;

namespace AdventureGame.Core.Models;


    public class Maze
    {
       
        public int Width { get; set; }
        public int Height { get; set; }
        public int commonMazeMeasure { get; set; } // to create square maze with one measure for width and height
        public TileType[,] TileFeature { get; set; } // 2D array to create all maze / width and height depended
        public (int x, int y) PositionInit { get; set; } // to initialize postions of objects such as player or exit in maze use it in tilefeature array
        public (int x , int y) PlayerPosition { get; set; } // to keep track of player position in maze
        
        public Maze(int commonMazeMeasure, MazeGeneratorLogics mazeGeneratorInstance)
        
        {
            Width = commonMazeMeasure;
            Height = commonMazeMeasure;
            TileFeature = new TileType[Width, Height];
            mazeGeneratorInstance.GenerateFinalMaze(this);  // when we give boundries for constructor, we generate maze immediately with this method   
        }

    }