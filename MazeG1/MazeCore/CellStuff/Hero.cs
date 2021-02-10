using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MazeCore.CellStuff
{
    public class Hero : BaseCell, IHero
    {
        private static Hero _singleHero;
        private int _money;
        /// <summary>
        /// Это singletone. Возвращает героя, если он уже был создан. 
        /// Создаст и вернёт героя, если его ещё не было создано
        /// </summary>
        public static IHero GetHero
        {
            get
            {
                if (_singleHero == null)
                {
                    _singleHero = new Hero(0, 0, null);
                }
          
                return _singleHero;
            }
        }

        public int Money //{ get; set; }
        {
            get => _money;
            set
            {
                if (value >= 0)
                {
                    _money = value;
                }
            }
        }

        private Hero(int x, int y, Maze maze) : base(x, y, '@', maze)
        {
            _money = 0;
        }

        public override bool TryToStep()
        {
            //TODO           

            throw new Exception("Герой не может стать на себя");

            return false;

        }
    }
}
