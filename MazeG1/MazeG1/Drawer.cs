using MazeCore;
using MazeCore.CellStuff;
using System;
using System.Linq;

namespace MazeG1
{
    class Drawer
    {
        public void DrawMaze(MazeCore.Maze maze)
        {
            Console.Clear();
            Console.WriteLine($"All cells: {maze.Cells.Count}." +
                $" Ground: {maze.Cells.OfType<Ground>().Count()}." +
                $" Coins: {maze.Cells.OfType<Coin>().Count()}");
            Console.WriteLine($"Money: {Hero.GetHero.Money}");

            for (int y = 0; y < maze.Height; y++)
            {
                Console.WriteLine();
                Console.Write($"{y}) ");
                for (int x = 0; x < maze.Width; x++)
                {
                    var cell = maze.CellsWithHero.Single(cell => cell.X == x && cell.Y == y);
                    Console.Write(cell.Symbol);
                }
            }
        }
    }
}
