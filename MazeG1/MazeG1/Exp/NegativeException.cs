using System;
using System.Collections.Generic;
using System.Text;

namespace MazeG1.Exp
{
    public class NegativeException : Exception
    {
        public override string Message => "Числа не бывают меньше нуля";
    }
}
