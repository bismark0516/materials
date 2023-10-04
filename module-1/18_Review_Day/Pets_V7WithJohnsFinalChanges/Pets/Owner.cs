using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetInfo
{
    // add a class caller Owner
    public class Owner
    {
        //property
        //name - read only
        //email - read only
        //procedure count - derived
        //procedures dictionary(string, decimal) - get, private set


        public string Name { get; }
        public string Email { get; }

        public Dictionary<string, decimal> Procedures { get; private set; } = new Dictionary<string, decimal>();
        public int ProcedureCount
        {
            get
            {
                return Procedures.Count;
            }
        }

        // constructor name and email
        public Owner(string name, string email)
        {
            Name = name;
            Email = email;
        }

        // method add procedure, description, price
        public void AddProcedure(string description, decimal price)
        {
            Procedures[description] = price;
        }

        //method decimal total price ( is friends and family)
        //10% discount for friends and family
        public decimal TotalPrice(bool friendsAndFamily)
        {
            decimal total = 0.0M;

            foreach(decimal price in Procedures.Values)
            {
                total += price;
            }

            if (friendsAndFamily)
            {
                total *= .9M;
            }

            return total;
        }

        // to string name method with email address, procedure count
        public override string ToString()
        {
            return $"{Name}, {Email}, {ProcedureCount}";
        }

    }
}
