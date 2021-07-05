using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    public class UserController : BaseApiController
    {
        IUnitOfWork unitOfWork;
        IMapper mapper;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<UserDto> GetUser()
        {
            var user = await unitOfWork.UserRepository.GetUserByIdAsync(User.GetUserId());
            var userDto = mapper.Map<UserDto>(user);
            return userDto;
        }


        [HttpGet("user-likes")]
        public async Task<ActionResult<List<DestinationDto>>> UserLikes()
        {
            var user = await unitOfWork.UserRepository.GetUserByUsernameAsync(User.GetUsername());

            return await unitOfWork.UserRepository.GetAllLikedDestinations(user.Id);

        }


        [HttpGet("user-reservations")]
        public async Task<ActionResult<List<ReservedDestinationsDto>>> UserReservations()
        {
            var user = await unitOfWork.UserRepository.GetUserByUsernameAsync(User.GetUsername());

            var userWithReservations = await unitOfWork.UserRepository.GetUserWithReservationsAsync(user.Id);

            List<ReservedDestinationsDto> list = new List<ReservedDestinationsDto>();



            foreach (Reservation item in userWithReservations.Reservations)
            {
                ReservedDestinationsDto r = new ReservedDestinationsDto
                {
                    DestinationId = item.Destination.Id,
                    DestinationHotel = item.Destination.Hotel,
                    DestinationCity = item.Destination.City,
                    EndDate = item.EndDate,
                    StartDate = item.StartDate,
                    NumberOfPeople = item.NumberOfPeople,
                    TotalPrice = item.TotalPrice
                };
                list.Add(r);
            }

            return list;
        }


        [HttpPost("like-destination/{destinationId}")]
        public async Task<ActionResult> UserLikes(int destinationId)
        {
            var userId = User.GetUserId();


            var user = await unitOfWork.UserRepository.GetUserWithLikesAsync(userId);


            Like like = new Like
            {
                AppUserId = user.Id,
                DestinationId = destinationId
            };

            user.Likes.Add(like);
            if (await unitOfWork.Complete()) return Ok();

            return BadRequest("Failed to like destination");


        }

        [HttpDelete("dislike-destination/{destinationId}")]
        public async Task<ActionResult> DeleteLike(int destinationId)
        {
            var userId = User.GetUserId();

            Like l = unitOfWork.UserRepository.GetLike(userId, destinationId);

            unitOfWork.UserRepository.DeleteLike(l);

            if (await unitOfWork.Complete()) return Ok();

            return BadRequest("Unable to delete like");

        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(UserEditDto uderEditDto)
        {
            var user = await unitOfWork.UserRepository.GetUserByUsernameAsync(User.GetUsername());





            mapper.Map(uderEditDto, user);
            unitOfWork.UserRepository.Update(user);
            if (await unitOfWork.Complete()) return NoContent();
            return BadRequest("Failed to update user");
        }
    }
}
