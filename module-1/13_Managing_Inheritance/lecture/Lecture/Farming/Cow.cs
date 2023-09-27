namespace Lecture.Farming
{
    public class Cow : FarmAnimal, ISellable
    {
        public override bool IsAsleep { get; set; }
        public decimal Price { get; }

        public Cow() : base("Cow", "moo")
        {
            Price = 1500;
        }
    }
}
