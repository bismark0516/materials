namespace Lecture.Farming
{
    /// <summary>
    /// A base farm animal class.
    /// </summary>
   
    //class
    public class FarmAnimal : IMakeSound 
    {


        //properties
        /// <summary>
        /// The farm animal's name.
        /// </summary>
        public string Name { get; }


        /// <summary>
        /// The farm animal's sound
        /// </summary>
        public string Sound { get; }

        /// <summary>
        /// Creates a new farm animal.
        /// </summary>
        /// <param name="name">The name which the animal goes by.</param>
        /// 
        


        //constructor
        public FarmAnimal(string name, string sound) 
        {
            Name = name;
            Sound = sound;
        }
    }
}
