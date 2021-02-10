using MazeCore.CellStuff;

namespace MazeCore
{
    public class Human
    {
        public string Name { get; set; }

        private int _age;
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                _age = value;
            }
        }

        public bool GetDrive => Age > 18;

        public int GetAge()
        {
            return Age;
        }

        public Human() { }

        public Human(string name)
        {
            Name = name;
            Age = 42;
        }

        public Human(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string FullName()
        {
            return $"{Name}({Age})";
        }

        public bool IsValid()
        {
            return Name != "";
        }
    }
}
