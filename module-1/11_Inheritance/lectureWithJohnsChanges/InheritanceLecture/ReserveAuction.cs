using InheritanceLecture.Auctioneering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceLecture
{
    public class ReserveAuction : Auction
    {
        private int reserveAmount;

        public ReserveAuction(int reserveAmount)
        {
            this.reserveAmount = reserveAmount;
        }

        public bool PlaceReserveBid(Bid bid)
        {
            bool result = false;

            if (bid.BidAmount >= reserveAmount)
            {
               result = PlaceBid(bid);
            }
            else
            {
                Console.WriteLine($"Bid doees not meet or exceet reserve amount of {reserveAmount}");
            }


            return result;
        }
    }
}
