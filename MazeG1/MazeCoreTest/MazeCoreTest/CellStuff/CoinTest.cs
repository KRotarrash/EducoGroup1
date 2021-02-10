using System;
using System.Collections.Generic;
using System.Text;
using MazeCore;
using MazeCore.CellStuff;
using Moq;
using NUnit.Framework;

namespace MazeCoreTest.CellStuff
{
    public class CoinTest
    {
        [Test]
        public void Coin_TryToStep()
        {
            var mazeMock = new Mock<IMaze>();
            mazeMock.SetupAllProperties();

            var heroMock = new Mock<IHero>();
            heroMock.SetupAllProperties();

            mazeMock.Setup(x => x.Hero).Returns(heroMock.Object);
            var coin = new Coin(0, 0, mazeMock.Object);
            
            var res = coin.TryToStep();

            Assert.AreEqual(true, res);

            Assert.AreEqual(1, heroMock.Object.Money);
        }
    }
}
