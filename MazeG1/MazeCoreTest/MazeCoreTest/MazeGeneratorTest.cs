using MazeCore;
using MazeCore.CellStuff;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeCoreTest.CellStuff
{
    public class MazeGeneratorTest
    {
        MazeGenerator mazeGenerator;
        private const int width = 10;
        private const int height = 10;
        private const double chanceOfCoin = 0.1;
        private const int maxCountOfWell = 3;

        [SetUp]
        public void Setup()
        {
            mazeGenerator = new MazeGenerator();
        }

        [Test]
        public void MazeGenerator_Generate()
        {
            var maze = mazeGenerator.Generate(width, height, chanceOfCoin, maxCountOfWell);

            var cellCount = maze.Cells.Count();
            var wallCount = maze.Cells.OfType<Wall>().Count();
            var groundCount = maze.Cells.OfType<Ground>().Count();
            var wellCount = maze.Cells.OfType<Well>().Count();

            Assert.AreEqual(width * height, cellCount);
            Assert.Greater(wallCount, 0);
            Assert.Greater(groundCount, 0);
            Assert.LessOrEqual(wellCount, maxCountOfWell);
        }
    }
}
