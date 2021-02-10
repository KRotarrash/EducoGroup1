using MazeCore;
using MazeCore.CellStuff;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeCoreTest.CellStuff
{
    public class GroundTest
    {
        [Test]
        public void Ground_TryToStep()
        {
            var mazeMock = new Mock<IMaze>();
            mazeMock.SetupAllProperties();
            var ground = new Ground(0, 0, mazeMock.Object);

            var res = ground.TryToStep();

            Assert.AreEqual(true, res);
        }
    }
}
