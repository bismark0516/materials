using System;
using System.Collections.Generic;
using System.Text;

namespace PetInfoClient.Exceptions
{
    public class PetAgeException : Exception
    {
        public PetAgeException(string message) : base(message)
        {
        }
    }
}
