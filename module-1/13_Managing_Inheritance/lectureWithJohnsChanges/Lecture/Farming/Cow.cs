namespace Lecture.Farming
{
    public class Cow : FarmAnimal, ISellable
    {
        public decimal Price { get; }
        public override bool IsAsleep { get; set; }

        public Cow() : base("Cow", "moo")
        {
            Price = 1500;
        }
    }
}
