﻿using HotelReservations.DAO;
using HotelReservations.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelReservations.Controllers
{
    [Route("reservations")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private IReservationDao reservationDao;
        private IHotelDao hotelDao;
        public ReservationsController(IHotelDao hotelDao, IReservationDao reservationDao)
        {
            this.hotelDao = hotelDao;
            this.reservationDao = reservationDao;
        }

        [HttpGet()]
        public List<Reservation> ListReservations()
        {
            return reservationDao.GetReservations();
        }

        [HttpGet("{id}")]
        public ActionResult<Reservation> GetReservation(int id)
        {
            Reservation reservation = reservationDao.GetReservationById(id);

            if (reservation != null)
            {
                return reservation;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("/hotels/{hotelId}/reservations")]
        public ActionResult<List<Reservation>> ListReservationsByHotel(int hotelId)
        {
            Hotel hotel = hotelDao.GetHotelById(hotelId);
            if (hotel == null)
            {
                return NotFound();
            }
            return reservationDao.GetReservationsByHotel(hotelId);
        }

        [HttpPost()]
        public ActionResult<Reservation> AddReservation(Reservation reservation)
        {
            Reservation added = reservationDao.CreateReservation(reservation);
            return Created($"/reservations/{added.Id}", added);
        }

        [HttpPut("{reservationId}")]
        public ActionResult<Reservation> UpdateReservation(int reservationId, Reservation reservation)
        {
            Reservation updated = reservationDao.UpdateReservation(reservation);
            return Ok(updated);
        }

        [HttpDelete("{reservationId}")]
        public ActionResult DelrteReservation(int reservationId)
        {
            int result = reservationDao.DeleteReservationById(reservationId);
            if (result == 1)
            {
                return Ok();
            }
            else
            {
                return NotFound("Reservation ot found");
            }
        }


    }
}
