using InheritanceLecture.Auctioneering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceLecture
{
    public class BuyoutAuction : Auction
    {
        private int buyoutAmount = 0; 
        public BuyoutAuction(int buyoutAmount)
        {
            this.buyoutAmount = buyoutAmount;
        }

        public bool PlaceBuyoutBid( Bid bid)
        {
            bool result = false;

            if (!HasEnded && bid.BidAmount >= buyoutAmount)
            {
                PlaceBid(bid);
                HasEnded = true;
            }
            else if (!HasEnded)
            {
                PlaceBid(bid);
            }
            else
            {
                Console.WriteLine("The buyout auction has ended.");
            }



            return result;
        }
    }
}
