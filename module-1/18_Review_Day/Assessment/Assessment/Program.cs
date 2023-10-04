using Assessment.Classes;
using System;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Assessment
{
    public class Program : TicketPurchase
    {
        public Program(string name, int numberOfTickets) : base(name, numberOfTickets)
        {

        }
        public override string ToString()
        {
            string message = ($"Ticket - {Name} - {BasePrice}");
            
            return message;
        }


        public static void Main()
        {
            TicketPurchase tickets = new TicketPurchase("Bob", 14);
            Console.WriteLine(tickets);

        }


    }
}




