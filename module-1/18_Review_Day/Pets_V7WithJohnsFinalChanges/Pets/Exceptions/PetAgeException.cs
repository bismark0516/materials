using System;
using System.Collections.Generic;
using System.Text;

namespace PetInfo.Exceptions
{
    public class PetAgeException : Exception
    {
        public PetAgeException(string message) : base(message)
        {
        }
    }
}
