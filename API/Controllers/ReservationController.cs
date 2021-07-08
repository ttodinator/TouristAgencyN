using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    /// <summary>
    /// Kontroler za rad sa rezervacijama
    /// </summary>
    public class ReservationController : BaseApiController
    {
        IUnitOfWork unitOfWork;
        IMapper mapper;

        public ReservationController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        /// <summary>
        /// Metoda koja cuva rezervaciju
        /// </summary>
        /// <param name="reservationDto"></param>
        /// <returns>Action result sa rezervacijom</returns>
        [HttpPost]
        public async Task<ActionResult> AddReservation(ReservationDto reservationDto)
        {
            var user = await unitOfWork.UserRepository.GetUserWithReservationsAsync(User.GetUserId());

            Reservation reservation = new Reservation
            {
                UserId = user.Id,
                DestinationId = reservationDto.DestinationId,
                StartDate = reservationDto.Dates[0],
                EndDate = reservationDto.Dates[1],
                TotalPrice = reservationDto.TotalPrice,
                NumberOfPeople = reservationDto.NumberOfPeople
            };

            user.Reservations.Add(reservation);


            if (await unitOfWork.Complete()) return Ok();

            return BadRequest("Failed to make a reservation");

        }


    }
}
