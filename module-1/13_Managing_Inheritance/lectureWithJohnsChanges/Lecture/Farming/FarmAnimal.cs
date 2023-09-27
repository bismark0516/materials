namespace Lecture.Farming
{
    /// <summary>
    /// A base farm animal class.
    /// </summary>
    public abstract class FarmAnimal : ISingable
    {
        /// <summary>
        /// The farm animal's name.
        /// </summary>
        public string Name { get; }

        private string sound;
        /// <summary>
        /// The farm animal's sound.
        /// </summary>
        public string Sound
        {
            get
            {
                if (IsAsleep)
                {
                    return "Burrrrrrrrrr";
                }
                else
                {
                    return sound;
                }
            }
            set
            {
                sound = value;
            }
        }

        /// <summary>
        /// Is the animal asleep?
        /// </summary>
        public abstract bool IsAsleep { get; set; }


        /// <summary>
        /// Creates a new farm animal.
        /// </summary>
        /// <param name="name">The name which the animal goes by.</param>
        /// <param name="sound">The sound that the animal makes.</param>
        public FarmAnimal(string name, string sound)
        {
            Name = name;
            Sound = sound;
        }
    }
}
