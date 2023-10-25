using HotelReservations.DAO;
using HotelReservations.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace InClassExample.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {

        // POST /reservations
        [HttpPost()]
        public ActionResult<Reservation> AddReservation(Reservation reservation)
        {
            IReservationDao dao = new ReservationMemoryDao();
            Reservation newReservation = dao.CreateReservation(reservation);
            return Ok(newReservation);
        }
    }
}
