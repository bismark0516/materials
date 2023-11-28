namespace PetInfoServer.Models
{
    public class Pet
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Type { get; set; }
        public int Owner { get; set; }
        public string OwnerName { get; set; } = "";
        public override string ToString()
        {
            return $"{Id} - {Name} - {Age} - {Type} - {Owner} - {OwnerName}";
        }
    }
}
