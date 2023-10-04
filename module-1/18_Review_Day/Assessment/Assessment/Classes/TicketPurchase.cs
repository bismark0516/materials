using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Classes
{
    public class TicketPurchase
    {
        public string Name { get; private set; }
        public int NumberOfTickets { get; private set; }

        public decimal BasePrice
        {
            get
            {
                return NumberOfTickets * 59.99M;
            }
        }

        public TicketPurchase(string name, int numberOfTickets)
        {
            Name = name;
            NumberOfTickets = numberOfTickets;
        }

        public decimal TotalPrice(bool earlyCheckIn, bool priorityRideAccess)
        {
            decimal totalPrice = BasePrice;


            if (earlyCheckIn == true && priorityRideAccess == true)
            {
                totalPrice = BasePrice + (NumberOfTickets * 10) + (NumberOfTickets * 50);
            }
            else if (earlyCheckIn == true)
            {
                totalPrice = BasePrice + (NumberOfTickets * 10);
            }
            else if (priorityRideAccess == true)
            {
                totalPrice = BasePrice + (NumberOfTickets * 50);
            }
           
               return totalPrice;
                



           
        }
        public override string ToString()
        {
            string message = ($"Ticket - {Name} - {BasePrice}");

            return message;
        }

    }
}
