using System;

namespace Lecture.Farming
{
    public sealed class Chicken : FarmAnimal
    {
        public override bool IsAsleep { get; set; }
        public Chicken() : base("Chicken", "cluck")
        {
        }

        public void LayEgg()
        {
            Console.WriteLine("Chicken laid an egg!");
        }
    }
}
