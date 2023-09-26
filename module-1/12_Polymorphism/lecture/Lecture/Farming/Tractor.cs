using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    public class Tractor : IMakeSound
    {
        public string Name { get; } = "Tractor";
        public string Sound { get; } = "Vroooom";
    }
}
