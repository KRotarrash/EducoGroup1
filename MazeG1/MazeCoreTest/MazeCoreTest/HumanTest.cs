using MazeCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeCoreTest.CellStuff
{
    

    public class HumanTest
    {
        /// <summary>
        /// Имя не пустое
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="answer">ожидаемый результат</param>
        [Test]
        [TestCase("", false)]
        [TestCase("Vasia", true)]
        public void Name_IsValid(string name, bool answer)
        {
            var human = new Human(name, 23);
            bool res = human.IsValid();
            Assert.AreEqual(answer, res);
        }
    }
}
