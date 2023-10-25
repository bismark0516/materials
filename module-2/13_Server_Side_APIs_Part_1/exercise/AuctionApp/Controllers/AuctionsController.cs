using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AuctionApp.Models;
using AuctionApp.DAO;
using System;

namespace AuctionApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly IAuctionDao dao;



        public AuctionsController(IAuctionDao auctionDao = null)
        {
            if (auctionDao == null)
            {
                dao = new AuctionMemoryDao();
            }
            else
            {
                dao = auctionDao;
            }

        }
        [HttpGet()]
        public List<Auction> GetAuctions(string title_like = "", double currentBid_lte = 0.0)
        {
            List<Auction> auction = new List<Auction>();

            if (title_like != "" && currentBid_lte > 0d)
            {
                return dao.GetAuctionsByTitleAndMaxBid(title_like, currentBid_lte);
            }
            if (title_like == "" && currentBid_lte == 0)
            {
                return dao.GetAuctions();
            }
            if (title_like != "")
            {
                return dao.GetAuctionByTitle(title_like);
            }
            if (currentBid_lte > 0d)
            {
                return dao.GetAuctionsByMaxBid(currentBid_lte);
            }
            else
            {
                return dao.GetAuctions();
            }
        }
        [HttpGet("{id}")]
        public Auction GetAuctionById(int id)
        {
            IAuctionDao dao = new AuctionMemoryDao();

            Auction auction = dao.GetAuctionById(id);
            return auction;
        }

        [HttpPost]
        public Auction CreateAuction(Auction auction)
        {
            return dao.CreateAuction(auction);
        }

    }
}

