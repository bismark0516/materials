namespace Lecture.Farming
{
    public class Pig : FarmAnimal, ISellable
    {
        public decimal Price { get; }
        public override bool IsAsleep { get; set; }

        public Pig() : base("Pig", "oink")
        {
            Price = 300;
        }
    }
}
