using InheritanceLecture.Auctioneering;
using System;

namespace InheritanceLecture
{
    class Program
    {
        static void Main(string[] args)
        {
            // // Create a new general auction
            // Console.WriteLine("Starting a general auction");
            // Console.WriteLine("-----------------");

            // Auction generalAuction = new Auction();

            // generalAuction.PlaceBid(new Bid("Josh", 1));

            //// Bid newBid = new Bid("Josh", 1);
            //// generalAuction.PlaceBid(newBid);


            // generalAuction.PlaceBid(new Bid("Fonz", 23));
            // generalAuction.PlaceBid(new Bid("Rick Astley", 13));
            // //....
            // //....
            // // This might go on until the auction runs out of time or hits a max # of bids





            //Console.WriteLine("Starting a Reseve Auction");
            //Console.WriteLine();

            //    ReserveAuction reserveAuction = new ReserveAuction(100);

            //reserveAuction.PlaceReserveBid(new Bid("John", 99));
            //reserveAuction.PlaceReserveBid(new Bid("Steve", 100));
            //reserveAuction.PlaceReserveBid(new Bid("John", 100));
            //reserveAuction.PlaceReserveBid(new Bid("Brian", 102));


            Console.WriteLine("Buyout Auction");

            BuyoutAuction buyoutAuction = new BuyoutAuction(200);

            buyoutAuction.PlaceBuyoutBid(new Bid("John", 99));
            buyoutAuction.PlaceBuyoutBid(new Bid("Sam", 99));
            buyoutAuction.PlaceBuyoutBid(new Bid("Brian", 102));
            buyoutAuction.PlaceBuyoutBid(new Bid("John", 200));
            buyoutAuction.PlaceBuyoutBid(new Bid("Brian", 201));





        }
    }
}
