using MazeCore;
using MazeCore.CellStuff;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeCoreTest.CellStuff
{
    public class WallTest
    {
        [Test]
        public void Wall_TryToStep()
        {
            var mazeMock = new Mock<IMaze>();
            mazeMock.SetupAllProperties();
            var wall = new Wall(0, 0, mazeMock.Object);

            var res = wall.TryToStep();

            Assert.AreEqual(false, res);
        }
    }
}
