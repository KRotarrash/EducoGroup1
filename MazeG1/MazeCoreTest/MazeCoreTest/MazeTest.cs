using MazeCore;
using MazeCore.CellStuff;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeCoreTest.CellStuff
{
    public class MazeTest
    {
        /// <summary>
        /// Будет проверять метод X
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="answer"></param>
        [Test]
        [TestCase(0, 0, true)]
        [TestCase(100, 0, false)]
        public void Maze_IsValid(int width, int height, bool answer)
        {
            var maze = new Maze(width, height);
            bool res = maze.IsValid();
            Assert.AreEqual(answer, res);
        }

        [Test]
        public void ReplaceCell()
        {
            //Подготовка
            var needToReplaceX = 5;
            var dontNeedToReplaceX = 7;
            var maze = new Maze(10, 10);
            var oldCellMockNeedToReplace = new Mock<ICell>();
            oldCellMockNeedToReplace.Setup(x => x.X).Returns(needToReplaceX);
            
            var oldCellMockDontNeedToReplace = new Mock<ICell>();
            oldCellMockDontNeedToReplace.Setup(x => x.X).Returns(dontNeedToReplaceX);

            maze.Cells = new List<ICell>() {
                oldCellMockNeedToReplace.Object,
                oldCellMockDontNeedToReplace.Object
            };
            var newCellMock = new Mock<ICell>();
            newCellMock.Setup(x => x.X).Returns(needToReplaceX);

            //Действие
            maze.ReplaceCell(newCellMock.Object);

            //Проверки
            var existOldCellToReplace = maze.Cells.IndexOf(oldCellMockNeedToReplace.Object) > -1;
            Assert.AreEqual(false, existOldCellToReplace);

            var existOldCellDontReplace = maze.Cells.IndexOf(oldCellMockDontNeedToReplace.Object) > -1;
            Assert.AreEqual(true, existOldCellDontReplace);

            var existNewCell = maze.Cells.IndexOf(newCellMock.Object) > -1;
            Assert.AreEqual(true, existNewCell);
        }
    }
}
