using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public class SquareWall : RectangleWall
    {
        public SquareWall(string name, string color, int sideLength):base(name,color,sideLength, sideLength)
        {
            sideLength = Length;

        }
        public override string ToString()
        {
            return $"{Name} ({Length}x{Length}) square";
        }
    }
    
    
}
