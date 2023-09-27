namespace Lecture.Farming
{
    public class Pig : FarmAnimal, ISellable
    {
        public override bool IsAsleep { get; set; }
        public decimal Price { get; }

        public Pig() : base("Pig", "oink")
        {
            Price = 300;
        }
    }
}
