using MazeCore;
using MazeCore.CellStuff;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeCoreTest.CellStuff
{
    public class WellTest
    {
        [Test]
        public void Well_TryToStep()
        {
            var mazeMock = new Mock<IMaze>();
            mazeMock.SetupAllProperties();

            var heroMock = new Mock<IHero>();
            heroMock.SetupAllProperties();
            //heroMock.Setup(x => x.Money).Returns(1); -- так не делаем
            //После heroMock.SetupAllProperties() к heroMock.Object обращаемся как к обычному объекту:
            heroMock.Object.Money = 1;

            mazeMock.Setup(x => x.Hero).Returns(heroMock.Object);

            var well = new Well(0, 0, mazeMock.Object);

            var res = well.TryToStep();

            Assert.AreEqual(true, res);

            Assert.AreEqual(0, heroMock.Object.Money);
        }
    }
}
