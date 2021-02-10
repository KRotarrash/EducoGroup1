using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Moq;
using MazeCore.CellStuff;

namespace MazeCoreTest.CellStuff
{
    
    public class HeroTest
    {
        /// <summary>
        /// Количество монет не должно быть отрицательным
        /// 
        /// не получается вызвать IsValid() для Hero
        /// 
        /// </summary>
        //[Test]
        //public void CoinCount_Is_non_negative()
        //{
        //    var heroMock = new Mock<IHero>();
        //    heroMock.Object.Money = -1;
        //    heroMock.Setup(x => x.IsValid()).Returns(true);
        //    bool res = heroMock.Object.IsValid();
        //    Assert.AreEqual(true, res);

        //    Assert.Throws<Exception>(() => Hero.GetHero.TryToStep());
        //}


        /// <summary>
        /// Проверка на срабатывание исключения если герой станет на себя        
        /// </summary>
        [Test]
        public void TryToStepTest()
        {            
            var hero = Hero.GetHero;
            Assert.Throws<Exception>(() => hero.TryToStep());
        }
    }
}
