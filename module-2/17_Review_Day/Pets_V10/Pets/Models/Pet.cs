using PetInfo.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetInfo.Models
{
    public class Pet
    {
        //static - belongs to class not any single object
        public static int nextPetId = 1;

        private int age = 0;

        public int Id { get; set; }
        public string Name { get; set; }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 0 || value > 120)
                {
                    throw new PetAgeException("Value must be between 0 and 120.");
                }
                age = value;
            }
        }

        public string Type { get; set; }

        public int Owner { get; set; }
        public string OwnerName { get; set; } = "";
        public override string ToString()
        {
            return $"{Id} - {Name} - {Age} - {Type} - {Owner} - {OwnerName}";
        }
    }
}
