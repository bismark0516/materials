using HotelReservations.DAO;
using HotelReservations.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InClassExample.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {

        // GET /hotels
        [HttpGet()]
        public ActionResult GetHotels(int stars = 0)
        {
            List<Hotel> hotels = null;

            if (stars == 0)
            {
                IHotelDao dao = new HotelMemoryDao();
                hotels = dao.GetHotels();
            }
            else
            {
                IHotelDao dao = new HotelMemoryDao();
                hotels = dao.GetHotelsByStars(stars);


            }

            return Ok(hotels);
        }



        // GET /hotels/5
        [HttpGet("{id}")]
        public ActionResult<Hotel> GetHotel(int id)
        {
            IHotelDao dao = new HotelMemoryDao();
            Hotel hotel = dao.GetHotelById(id);
            return hotel;
        }
    }
}
