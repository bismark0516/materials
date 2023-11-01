using System;
using System.Collections.Generic;
using System.Text;

namespace PetInfoServer.Exceptions
{
    public class PetAgeException : Exception
    {
        public PetAgeException(string message) : base(message)
        {
        }
    }
}
