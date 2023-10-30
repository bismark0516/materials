using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetInfoClient.Models
{
    // add a class caller Owner
    public class Owner
    {
        //property
        //name - read only
        //email - read only
        //procedure count - derived
        //procedures dictionary(string, decimal) - get, private set

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Owner(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public Owner()
        {
        }

        public override string ToString()
        {
            return $"{Id} - {Name} - {Email}";
        }

    }
}
