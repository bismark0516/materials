using RestSharp;
using System.Collections.Generic;
using AuctionApp.Models;
using System;

namespace AuctionApp.Services
{
    public class AuctionApiService
    {
        public IRestClient client;

        public AuctionApiService(string apiUrl)
        {
            client = new RestClient(apiUrl);
        }

        public List<Auction> GetAllAuctions()
        {
            List<Auction> auction = new List<Auction>();

            RestRequest requestAll = new RestRequest("auctions");
            IRestResponse<List<Auction>> response = client.Get<List<Auction>>(requestAll);

            if (response.IsSuccessful)
            {
                auction = response.Data;
            }
            else
            {
                throw new Exception("Error" + response.ErrorMessage);
            }

            return auction;
        }
        
        public Auction GetDetailsForAuction(int auctionId)
        {
            RestRequest request = new RestRequest($"auctions/{auctionId}");
            IRestResponse<Auction> response = client.Get<Auction>(request);

            if (response.IsSuccessful)
            {
                return response.Data;
            }
            else
            {
                throw new Exception("Error" + response.ErrorMessage);
            }
                        
        }

        public List<Auction> GetAuctionsSearchTitle(string searchTerm)
        {
            List<Auction> auction = new List<Auction>();

            RestRequest request = new RestRequest($"auctions?title_like={searchTerm}");
            //auctions?title_like=<*value*>
            IRestResponse<List<Auction>> response = client.Get<List<Auction>>(request);

            if (response.IsSuccessful)
            {
                auction = response.Data;
            }
            else
            {
                throw new Exception("Error" + response.ErrorMessage);
            }
            return auction;
           
        }

        public List<Auction> GetAuctionsSearchPrice(double searchPrice)
        {
            List<Auction> auction = new List<Auction>();

            RestRequest request = new RestRequest($"auctions?currentBid_lte={searchPrice}");
            IRestResponse<List<Auction>> response = client.Get<List<Auction>>(request);

            if (response.IsSuccessful)
            {
                auction =  response.Data;
            }
            else
            {
                throw new Exception("Error" + response.ErrorMessage);
            }

            return auction;
        }
    }
}
