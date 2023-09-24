using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAndObjectExample
{
    public class Pet
    {
        private string ownerName;
        private string petType;
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
        public string PetType
        {
            get
            {
                return petType;
            }
        }
        public Pet()
        {

        }

        public Pet(string petName, string petType)
        {
            PetName = petName;
            this.petType = petType;
        }

        public string PetInfo()
        {
            return PetName + " - " + Owner;
        }
    }
}
