using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AuctionApp.Models;
using AuctionApp.DAO;
using AuctionApp.Exceptions;

namespace AuctionApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly IAuctionDao dao;

        public AuctionsController(IAuctionDao auctionDao)
        {
            dao = auctionDao;
        }

        [HttpGet]
        public List<Auction> List(string title_like = "", double currentBid_lte = 0)
        {
            if (title_like != "")
            {
                return dao.GetAuctionsByTitle(title_like);
            }
            if (currentBid_lte > 0)
            {
                return dao.GetAuctionsByMaxBid(currentBid_lte);
            }

            return dao.GetAuctions();
        }

        [HttpGet("{id}")]
        public ActionResult<Auction> Get(int id)
        {
            Auction auction = dao.GetAuctionById(id);
            if (auction != null)
            {
                return Ok(auction);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Auction> Create(Auction auction)
        {
            Auction auctions = dao.CreateAuction(auction);
            return Created($"/auctions/{auctions.Id}", auctions);
        }

        [HttpPut("/auctions/{id}")]
        public ActionResult<Auction> Update(Auction auctions, int id)
        {
            auctions.Id = id;
            try
            {
                Auction auction = dao.UpdateAuction(auctions);
                return Ok(auction);

            }
            catch (DaoException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Auction> Delete(int id)
        {
            int delete = dao.DeleteAuctionById(id);
            if(delete == 1)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
