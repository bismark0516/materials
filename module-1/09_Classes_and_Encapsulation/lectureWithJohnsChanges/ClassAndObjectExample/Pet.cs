using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAndObjectExample
{
    public class Pet
    {
        private string ownerName;
        public string PetName { get; set; }

        public string Owner
        {
            get
            {
                return ownerName;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    ownerName = "unknown";
                }
                else
                {
                    ownerName = value;
                }
            }
        }

        public Pet()
        {

        }

        public Pet(string petName)
        {
            PetName = petName;
        }

        public string PetInfo()
        {
            return PetName + " - " + Owner;
        }
    }
}
