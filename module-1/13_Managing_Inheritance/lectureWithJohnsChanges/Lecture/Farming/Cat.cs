using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    public class Cat : FarmAnimal
    {
        public override bool IsAsleep { get; set; }
        public Cat() : base("Cat", "Meow")
        {
            IsAsleep = true;
        }
    }
}
