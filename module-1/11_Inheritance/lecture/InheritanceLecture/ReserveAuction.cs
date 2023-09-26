using InheritanceLecture.Auctioneering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceLecture
{       // the colon represents inheritance
    public class ReserveAuction : Auction
    {
        //instance variable, or a field, class level variable, 
        private int reserveAmount;


        //constructors
        public ReserveAuction ( int reserveAmount)
        {
            this.reserveAmount = reserveAmount;
        }

        public override bool PlaceBid(Bid bid)
        {
            bool result = false;

            if (bid.BidAmount >= reserveAmount)
            {
                result = base.PlaceBid(bid);
            }
            else
            {
                Console.WriteLine( $"Bid does not meet or exceed reserve amount of {reserveAmount}");
            }





            return result;
        }


    }

}
