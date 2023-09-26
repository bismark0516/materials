using InheritanceLecture.Auctioneering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceLecture
{
    public class BuyoutAuction : Auction
    {
        private int buyOutAmount = 0;
        public BuyoutAuction(int buyOutAmount)
        {
           this.buyOutAmount = buyOutAmount;
        }



        //public bool PlaceBuyOutBid(Bid bid)

        public override bool PlaceBid (Bid bid)
        {
            bool result = false;

            if (!HasEnded && bid.BidAmount>= buyOutAmount)
            {
                //PlaceBid(bid);
                base.PlaceBid(bid);
                HasEnded = true;
            }
            else if (!HasEnded)
            {
                //PlaceBid(bid);
               base.PlaceBid(bid);
            }
            else
            {
                Console.WriteLine("The buy auction has ended" );
            }


            return result;
        }
    }
}
